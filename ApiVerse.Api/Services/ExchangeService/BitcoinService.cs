using ApiVerse.Api.Abstract.ExchangeAbstracts;
using ApiVerse.Api.Models.ExchangeModels;
using System.Text.Json;

namespace ApiVerse.Api.Services.ExchangeService
{
    public class BitcoinService : IBitcoinService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;


        public BitcoinService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<BitcoinValueViewModel> GetBitcoinInformation()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://binance43.p.rapidapi.com/ticker/24hr?symbol=BTCTRY"),
                Headers =
                {
                    { "x-rapidapi-key", _configuration["ApiKey:Key"] },
                    { "x-rapidapi-host", "binance43.p.rapidapi.com" },
                },
            };
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var bitcoinValue = JsonSerializer.Deserialize<BitcoinValueViewModel>(body);
                return bitcoinValue;
            }
        }
    }
}