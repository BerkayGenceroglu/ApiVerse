using ApiVerse.Api.Models.MovieModels;
using ApiVerse.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ApiVerse.UI.Controllers
{
    public class MovieUIController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public MovieUIController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult MovieList()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchMovie(string title)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7239/api/MovieApi/{title}");
            if (response.IsSuccessStatusCode)
            {
                var jsonStringData = await response.Content.ReadAsStringAsync();

                // Veriyi dizi (Array) olarak karşılıyoruz
                var movies = JsonConvert.DeserializeObject<ResultMovieDto.Item[]>(jsonStringData);

                if (movies != null && movies.Length > 0)
                {
                    try
                    {
                        // 2. ADIM: OpenAI Servisine gidip "Günün Seçimi"ni alıyoruz
                        // Bu metot bize tek bir film için görsel, fragman ve yorum dönecek
                        var aiSmartData = await GetAiSmartData(movies, title);

                        // 3. ADIM: AI verisini View'a taşımak için ViewBag kullanıyoruz
                        ViewBag.AiData = aiSmartData;
                    }
                    catch (Exception ex)
                    {
                        // OpenAI'da bir hata olursa uygulama çökmesin diye boş geçiyoruz
                        ViewBag.AiData = null;
                    }
                }

                return View("MovieList", movies);
            }

            return View("MovieList", Array.Empty<ResultMovieDto.Item>());
        }

        public async Task<MovieAiContainerDto> GetAiSmartData(ResultMovieDto.Item[] movies, string searchQuery)
        {
            var apiKey = _configuration["OpenAIApiKey:Key"];
            var movieTitles = string.Join(", ", movies.Select(x => x.title));

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            var prompt = $@"Kullanıcı '{searchQuery}' kelimesini arattı ve şu filmler listelendi: {movieTitles}.
    
            Senden isteğim:
            1. Bu listeden en izlenesi filmi seç.Açıklamada Benim Görüşüm,Benim Düşüncem, Benim Tarzım gibi ifadeler kullanma profesyonel bir flim küratörüsün.
            2. Neden onu seçtiğini samimi bir dille açıkla.
            3. Seçtiğin bu tek film için gerçek bir afiş URL'si ve YouTube fragman ID'si bul.

            SADECE ŞU JSON FORMATINDA CEVAP VER:
            {{
                ""AiRecommendation"": ""...açıklama..."",
                ""ChosenMovieTitle"": ""...filmin adı..."",
                ""PosterUrl"": ""..."",
                ""TrailerId"": ""...""
            }}";

            var payload = new
            {
                model = "gpt-4o-mini",
                temperature = 0.7,
                messages = new[] {
                new { role = "system", content = "Sen profesyonel bir film küratörüsün." },
                new { role = "user", content = prompt }
            },
                response_format = new { type = "json_object" }
            };

            var response = await client.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", payload);
            var content = await response.Content.ReadAsStringAsync();
            var dynamicResult = JsonConvert.DeserializeObject<dynamic>(content);
            string jsonOutput = dynamicResult.choices[0].message.content;
            var lastvalue = JsonConvert.DeserializeObject<MovieAiContainerDto>(jsonOutput);
            return lastvalue;
        }
    }
}
