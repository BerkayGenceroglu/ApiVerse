using ApiVerse.Api.Abstract.NewsAbstracts;
using ApiVerse.Api.Models.NewsModels;
using System.Text.Json;

namespace ApiVerse.Api.Services.NewsService
{
    public class NewsService : INewsService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public NewsService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<ResultNewsResult> SearchNewsAsync(string query, int max = 10)
        {
            var apikey = _configuration["GNewsApi:Key"];
            var from = DateTime.UtcNow.AddDays(-7).ToString("yyyy-MM-ddTHH:mm:ssZ");
            var url = $"https://gnews.io/api/v4/search?q={Uri.EscapeDataString(query)}&lang=tr&max={max}&from={from}&apikey={apikey}";

            var response = await _httpClient.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var result = JsonSerializer.Deserialize<ResultNewsResult>(json, options);

            if (result?.articles != null)
            {
                var oneWeekAgo = DateTime.UtcNow.AddDays(-7);
                result.articles = result.articles
                    .Where(a => a.publishedAt >= oneWeekAgo)
                    .OrderByDescending(a => a.publishedAt)
                    .ToArray();
            }

            return result;
        }
    }
}
