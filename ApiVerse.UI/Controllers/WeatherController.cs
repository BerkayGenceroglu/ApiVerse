using ApiVerse.Api.Models.WeatherModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ApiVerse.UI.Controllers
{
    [Authorize]
    public class WeatherController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public WeatherController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult WeatherPage()
        {
            return View(new WeatherResponse());
        }

        [HttpPost]
        public async Task<IActionResult> WeatherPage(string cityname)
        {
            if (string.IsNullOrEmpty(cityname)) return View(new WeatherResponse());

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7239/api/WeatherApi/{cityname}");
            ViewBag.SearchCity = cityname;
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var weatherObject = JsonConvert.DeserializeObject<WeatherResponse>(jsonData);

                // --- OpenAI Entegrasyonu Başlıyor ---
                if (weatherObject?.list != null && weatherObject.list.Length > 0)
                {
                    var current = weatherObject.list[0];
                    weatherObject.AIRecommendations = await GetOpenAIRecommendations(
                        cityname,
                        current.weather[0].description,
                        current.main.temprature
                    );
                }

                return View(weatherObject);
            }

            return View(new WeatherResponse()); 
        }

        private async Task<string> GetOpenAIRecommendations(string city, string description, float temp)
        {
            var openAiKey = _configuration["OpenAIApiKey:Key"]; // appsettings.json'dan çek
            var client = _httpClientFactory.CreateClient();

            var prompt = $@"
            {city} şehrinde şu an hava durumu: {description}, sıcaklık: {temp}°C.

            Bu koşullara uygun olarak:
            - {city} şehrine özgü
            - Gerçekçi ve uygulanabilir
            - Kısa ve yaratıcı

            toplam 5 farklı aktivite öner.

            Kurallar:
            - Her öneri 1 cümle olsun
            - Maddeler numaralı liste şeklinde yazılsın
            - Eğer aktivite şehre özgüyse parantez içinde belirt (Örn: 'İstanbul'a özel')
            - Genel ve klişe önerilerden kaçın (örneğin sadece 'yürüyüş yap' yazma, daha spesifik ol)

            Sadece listeyi ver, ekstra açıklama ekleme.
            ";

            var requestBody = new
            {
                model = "gpt-4o-mini",
                temperature = 0.7,
                messages = new[] { new { role = "user", content = prompt } }
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions");
            request.Headers.Add("Authorization", $"Bearer {openAiKey}");
            request.Content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                dynamic json = JsonConvert.DeserializeObject(result);
                return json.choices[0].message.content;
            }
            return "Aktivite önerileri şu an alınamadı.";
        }
    }
}
