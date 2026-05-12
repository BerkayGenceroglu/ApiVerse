using ApiVerse.Api.Models.FootballModels;
using System.Text.Json;

namespace ApiVerse.UI.Service
{
    public class FootballClientService
    {
        private readonly HttpClient _httpClient;

        public FootballClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<FixtureMatch>> GetLastWeekAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7239/api/Sports/football/fixtures/lastweek");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<List<FixtureMatch>>(json, options) ?? new List<FixtureMatch>();
        }

        public async Task<List<FixtureMatch>> GetThisWeekAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7239/api/Sports/football/fixtures/thisweek");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<List<FixtureMatch>>(json, options) ?? new List<FixtureMatch>();
        }

        public async Task<List<FixtureMatch>> GetNextWeekAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7239/api/Sports/football/fixtures/nextweek");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<List<FixtureMatch>>(json, options) ?? new List<FixtureMatch>();
        }
    }
}
