using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace ApiVerse.UI.Controllers
{
    [Authorize]
    public class LocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public LocationController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult DistanceCalculation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetAiTravelAdvice(string origin, string destination, string distance, string duration, string mode)
        {
            if (string.IsNullOrEmpty(origin) || string.IsNullOrEmpty(destination))
                return Json(new { advice = "Veri eksik geldi." });

            // API Key'inizi appsettings.json'dan çekin
            var openAiKey = _configuration["OpenAIApiKey:Key"];
            var client = _httpClientFactory.CreateClient();

            string prompt =
                            $"Şu an saat {DateTime.Now:HH:mm}. " +
                            $"{origin} noktasından {destination} noktasına {mode} ulaşım türüyle gidiliyor. " +
                            $"Mesafe: {distance}, Tahmini süre: {duration}. " +
                            $"Trafik durumu, olası aksaklıklar, konfor durumu ve alternatif rota önerilerini dikkate alarak " +
                            $"3 kısa, net ve akıllıca öneri ver." +
                            $"Cevap formatı: Önce 2-3 cümlelik kısa bir durum analizi yap. Ardından madde madde net öneriler ver. En sonda güvenli sürüşe dikkat çeken kısa bir kapanış cümlesi ekle ve iyi yolculuk dile." +
                            $"Giriş klişeleri ('Elbette', 'Tabii ki' vb.) kullanma.";

            var requestBody = new
            {
                model = "gpt-4o-mini",
                temperature = 0.7,
                messages = new[] { new { role = "user", content = prompt } }
            };
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions");
            request.Headers.Add("Authorization", $"Bearer {openAiKey}");
            request.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json");

            try
            {
                var response = await client.SendAsync(request);
                var responseString = await response.Content.ReadAsStringAsync();

                using var doc = System.Text.Json.JsonDocument.Parse(responseString);
                string aiResponse = doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();

                return Json(new { advice = aiResponse });
            }
            catch (Exception)
            {
                return Json(new { advice = "Yapay zeka şu an meşgul, ancak genel tavsiyem navigasyonu takip etmenizdir." });
            }
        }
    }
}
