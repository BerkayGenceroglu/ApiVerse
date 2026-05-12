using ApiVerse.Api.Abstract.FootballAbstracts;
using ApiVerse.UI.Models;
using System.Text;
using System.Text.Json;

namespace ApiVerse.UI.Service
{
    public class PredictionService 
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly FootballClientService _footballClientService;

        public PredictionService(IHttpClientFactory httpClientFactory, IConfiguration configuration, FootballClientService footballClientService)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _footballClientService = footballClientService;
        }

        public async Task<List<MatchPrediction>> GetPredictionsAsync()
        {
            var lastWeek = await _footballClientService.GetLastWeekAsync();   
            var thisWeek = await _footballClientService.GetThisWeekAsync();   
            var nextWeek = await _footballClientService.GetNextWeekAsync();

            // Geçen + bu hafta sonuçlarını prompt'a ekle
            var results = string.Join("\n", lastWeek.Concat(thisWeek).Select(m =>
             $"{m.Home?.Name} vs {m.Away?.Name} - Skor: {m.Status?.ScoreStr}"));


            var upcoming = string.Join("\n", nextWeek.Select(m =>
                $"{m.Home?.Name} vs {m.Away?.Name}"));


            var prompt = @"
            Süper Lig'in son iki haftasında oynanan maç sonuçları ve takımların form durumları aşağıdadır:

            " + results + @"

            Gelecek hafta oynanacak maçlar:

            " + upcoming + @"

            Görev:
            Her maç için kısa ama açıklayıcı bir tahmin yap. Tahminlerinde şu unsurları mutlaka dikkate al:
            - Takımların son form durumu
            - Son maç performansları
            - Gol atma / yeme eğilimleri
            - Genel güç dengesi

            Tahminler sadece tek cümle olmasın, kısa bir analiz içersin.
            Örnek: 
            'Gollü bir maç bekleniyor, Galatasaray'ın son haftalardaki formu ve hücum gücü nedeniyle Galatasaray kazanır.'

            Çıktı formatı:
            SADECE JSON döndür, başka hiçbir açıklama yazma.

            Format:
            [
              {
                ""match"": ""Galatasaray vs Fenerbahçe"",
                ""prediction"": ""Gollü bir maç bekleniyor, Galatasaray'ın formda olmasından dolayı Galatasaray kazanır"",
                ""confidence"": ""Yüksek""
              }
            ]

            Kurallar:
            - Her maç için ayrı obje oluştur
            - prediction alanı analiz + sonuç içersin
            - confidence: Düşük / Orta / Yüksek olarak ver
            - JSON dışında hiçbir şey yazma
            ";

            var client = _httpClientFactory.CreateClient();
            var apiKey = _configuration["OpenAIApiKey:Key"];

            var requestBody = new
            {
                model = "gpt-4o-mini",
                messages = new[] { new { role = "user", content = prompt } },
                temperature = 0.7
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions");
            request.Headers.Add("Authorization", $"Bearer {apiKey}");
            request.Content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var openAiResponse = JsonSerializer.Deserialize<OpenAiResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            var content = openAiResponse?.Choices?[0]?.Message?.Content ?? "[]";

            // Markdown code block temizle
            content = content.Trim();
            if (content.StartsWith("```"))
            {
                content = content.Replace("```json", "").Replace("```", "").Trim();
            }

            return JsonSerializer.Deserialize<List<MatchPrediction>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new();
        }
    }
}
