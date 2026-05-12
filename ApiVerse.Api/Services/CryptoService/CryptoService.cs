using ApiVerse.Api.Abstract.CryptoAbstracts;
using ApiVerse.Api.Models.CryptoModels;
using System.Text.Json;

namespace ApiVerse.Api.Services.CryptoService
{
    public class CryptoService : ICryptoService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public CryptoService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<List<CryptoResponseViewModel.CryptoResult>> GetTopCryptosAsync()
        {
           
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://crypto-news51.p.rapidapi.com/api/v1/mini-crypto/prices?base_currency=TRY&page=1&page_size=20"),
                Headers =
                {
                    { "x-rapidapi-key", _configuration["ApiKey:Key"]},
                    { "x-rapidapi-host", "crypto-news51.p.rapidapi.com" },
                },
            };
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var jsonData = JsonSerializer.Deserialize<CryptoResponseViewModel>(body, options);
                return jsonData?.Results ?? new List<CryptoResponseViewModel.CryptoResult>();
            }
        }
    }
}
