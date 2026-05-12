using ApiVerse.Api.Abstract;
using ApiVerse.Api.Models.WeatherModels;
using System.Text.Json;

namespace ApiVerse.Api.Services
{
    public class WeatherApiService : IWeatherApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public WeatherApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<WeatherResponse> GetWeatherAsync(string cityName)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://weather-api167.p.rapidapi.com/api/weather/forecast?place={cityName}&cnt=3&units=metric&lang=tr"),
                Headers =
            {
                { "x-rapidapi-key", _configuration["ApiKey:Key"] },
                { "x-rapidapi-host", "weather-api167.p.rapidapi.com" },
                { "Accept", "application/json" },
            },
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var data = JsonSerializer.Deserialize<WeatherResponse>(body, options);
                return data;
            }
        }
    }
}
