using ApiVerse.Api.Abstract.ExchangeAbstracts;
using ApiVerse.Api.Models.ExchangeModels;
using System.Text.Json;

namespace ApiVerse.Api.Services.ExchangeService
{
    public class MoneyService : IMoneyService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public MoneyService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<CurrencyRateViewModel> GetCurrencyRateAsync()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://exchange-rate-api1.p.rapidapi.com/latest?base=TRY"),
                Headers =
            {
                { "x-rapidapi-key", _configuration["ApiKey:Key"] },
                { "x-rapidapi-host", "exchange-rate-api1.p.rapidapi.com" },
            },
            };
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var currencyApiResponse = JsonSerializer.Deserialize<CurrencyApiResponse>(json,options);
              
                return new CurrencyRateViewModel()
                {
                    Base = "TRY",
                    USD = Math.Round(1 / (decimal)currencyApiResponse.rates.USD, 2),
                    EUR = Math.Round(1 / (decimal)currencyApiResponse.rates.EUR, 2),
                    LastUpdate = currencyApiResponse.time_update.time_utc.ToString("yyyy-MM-dd HH:mm:ss")
                };
            }
        }
    }
}
