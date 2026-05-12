using ApiVerse.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using System.Threading.Tasks;
using static ApiVerse.Api.Models.FuelModels.FuelPriceResponse;

namespace ApiVerse.UI.Controllers
{
    public class FuelController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public FuelController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<IActionResult> FuelPage()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync("https://localhost:7239/api/Fuel/TurkeyFuelPrice");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var fuelPrices = System.Text.Json.JsonSerializer.Deserialize<FuelPrice>(jsonString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                var aiComment = await GetAiFuelAnalysis(fuelPrices);
                ViewBag.AiComment = aiComment;
                return View(fuelPrices);
            }
            return View();
        }

        private async Task<string> GetAiFuelAnalysis(FuelPrice model)
        {
            var apiKey = _configuration["OpenAIApiKey:Key"];
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            var prompt = $@"
        Aşağıdaki Türkiye akaryakıt fiyatlarını analiz et ve profesyonel bir değerlendirme notu oluştur.
        
        ⛽ VERİLER:
        - Benzin: {model.Gasoline} ₺/L
        - Motorin: {model.Diesel} ₺/L
        - LPG: {model.Lpg} ₺/L

        📌 GÖREV:
        - Bu fiyatları Avrupa ortalamasıyla karşılaştır
        - Türkiye'deki akaryakıt fiyatlarının genel seyrini yorumla
        - Döviz kuru ve küresel petrol fiyatlarıyla ilişkisini analiz et
        - Kısa vadeli fiyat beklentisi hakkında tahmin üret
        - Tüketici ve sürücüler açısından değerlendir

        ⚠️ ÖNEMLİ:
        - Kesin ifade kullanma (garanti, kesin artacak gibi)
        - Yüzeysel olmasın, detaylı analiz yap
        - En az 5-6 cümle yaz

        📌 SON CÜMLE:
        Mutlaka 'Bu analiz yalnızca bilgilendirme amaçlıdır.' ifadesi ile bitir.
        ";

            var requestBody = new
            {
                model = "gpt-4o",
                messages = new[] { new { role = "user", content = prompt } },
                temperature = 0.7
            };

            var response = await client.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", requestBody);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                dynamic result = JsonConvert.DeserializeObject(jsonResponse);
                return result.choices[0].message.content;
            }

            return "Akaryakıt analizi şu anda yapılamıyor. Lütfen daha sonra tekrar deneyiniz.";
        }
    }
}
