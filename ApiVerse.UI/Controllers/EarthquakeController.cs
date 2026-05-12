using ApiVerse.Api.Models.EarthquakeModels;
using ApiVerse.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiVerse.UI.Controllers
{
    public class EarthquakeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public EarthquakeController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<IActionResult> LiveEarthquakePage()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7239/api/Earthquake/live");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<ResultEarthquakeModel>(jsonString);
                return View(data);
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> EarthquakeByCityPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EarthquakeByCityPage(string city)
        {
            if (string.IsNullOrEmpty(city)) return View();

            var client = _httpClientFactory.CreateClient();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            // ── 1. Deprem verisi ─────────────────────────────────────────────────────
            var response = await client.GetAsync(
                $"https://localhost:7239/api/Earthquake/nearby?city={city}&radiusKm=300");

            if (!response.IsSuccessStatusCode)
                return View(new ResultEarthquakeModel
                {
                    events = new List<ResultEarthquakeModel.EarthquakeEvent>()
                });

            var jsonString = await response.Content.ReadAsStringAsync();
            var eventList = JsonSerializer.Deserialize<List<ResultEarthquakeModel.EarthquakeEvent>>(jsonString, options);

            var modelForView = new ResultEarthquakeModel
            {
                events = eventList,
                total_returned = eventList?.Count ?? 0
            };

            ViewBag.SearchCity = city;

            // ── 2. OpenAI analizi ────────────────────────────────────────────────────
            ViewBag.AiAnalysis = await GetEarthquakeAnalysisAsync(city, modelForView, client, options);

            return View(modelForView);
        }

        // ─────────────────────────────────────────────────────────────────────────────
        // OpenAI'ya istek at, JSON parse et, EqAiAnalysis döndür
        // ─────────────────────────────────────────────────────────────────────────────
        private async Task<EqAiAnalysis> GetEarthquakeAnalysisAsync(
            string city,
            ResultEarthquakeModel model,
            HttpClient client,
            JsonSerializerOptions options)
        {
            try
            {
                var events = model.events ?? new List<ResultEarthquakeModel.EarthquakeEvent>();

                double maxMag = events.Any() ? events.Max(e => e.preferred_data.magnitude) : 0;
                double avgMag = events.Any() ? events.Average(e => e.preferred_data.magnitude) : 0;
                double minDepth = events.Any() ? events.Min(e => e.preferred_data.depth_km) : 0;

                var top5 = events.Take(5).Select(e => new
                {
                    magnitude = e.preferred_data.magnitude,
                    depth_km = e.preferred_data.depth_km,
                    location = e.preferred_data.location?.description,
                    timestamp = e.preferred_data.timestamp_local
                });

                var prompt = $@"
                Sen deneyimli bir deprem ve jeoloji uzmanısın.
                Görevin, verilen deprem verilerini analiz ederek sakin, teknik ve halkın anlayabileceği bir değerlendirme üretmektir.

                Şehir: {city}

                DEPREM VERİLERİ:
                - Toplam deprem sayısı: {model.total_returned}
                - En yüksek büyüklük: {maxMag:F1}
                - Ortalama büyüklük: {avgMag:F1}
                - En sığ derinlik: {minDepth:F1} km
                - İlk 5 deprem kaydı:
                {JsonSerializer.Serialize(top5)}

                ANALİZ KURALLARI:
                - Panik oluşturacak ifadeler kullanma.
                - Kesin tahminlerde bulunma.
                - Bilimsel ve nesnel dil kullan.
                - Kısa, anlaşılır ve profesyonel cevap ver.
                - Tüm metinler Türkçe olmalı.
                - Öneriler kısa ve uygulanabilir olsun.
                - JSON dışında hiçbir açıklama yazma.
                - Markdown kullanma.
                - Geçersiz JSON üretme.

                Aşağıdaki JSON şemasına %100 uygun cevap ver:

                {{
                  ""risk_level"": ""düşük"",
                  ""durum_analizi"": ""Bölgedeki deprem hareketliliğine dair 2-3 cümlelik teknik değerlendirme."",
                  ""oneriler"": [
                    ""Kısa öneri 1"",
                    ""Kısa öneri 2"",
                    ""Kısa öneri 3""
                  ],
                  ""acil_notlar"": [
                    ""Deprem anında yapılacak madde 1"",
                    ""Deprem anında yapılacak madde 2"",
                    ""Deprem anında yapılacak madde 3"",
                    ""Deprem anında yapılacak madde 4""
                  ]
                }}

                ÖNEMLİ:
                - Sadece geçerli JSON döndür.
                - Açıklama, not veya ek metin yazma.
                ";

                var requestBody = new
                {
                    model = "gpt-4o",
                    messages = new[]
                    {
                new { role = "user", content = prompt }
                  },
                    response_format = new { type = "json_object" }
                };

                var httpRequest = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions");
                httpRequest.Headers.Add("Authorization", $"Bearer {_configuration["OpenAIApiKey:Key"]}");
                httpRequest.Content = new StringContent(
                    JsonSerializer.Serialize(requestBody),
                    Encoding.UTF8,
                    "application/json");

                var aiResponse = await client.SendAsync(httpRequest);
                if (!aiResponse.IsSuccessStatusCode) return EqAiAnalysis.Fallback();

                var aiJson = await aiResponse.Content.ReadAsStringAsync();
                var aiResult = JsonSerializer.Deserialize<OpenAiChatResponse>(aiJson, options);
                var content = aiResult?.Choices?.FirstOrDefault()?.Message?.Content ?? "";

                var analysis = JsonSerializer.Deserialize<EqAiAnalysis>(content, options);
                return analysis ?? EqAiAnalysis.Fallback();
            }
            catch
            {
                return EqAiAnalysis.Fallback();
            }
        }
    }
}
