using ApiVerse.Api.Abstract.ExchangeAbstracts;
using ApiVerse.Api.Models.ExchangeModels;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiVerse.Api.Services.ExchangeService
{
    public class GoldService : IGoldService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public GoldService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<ResultGoldİnfoViewModel> GetGoldİnformation()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://harem-altin-live-gold-price-data.p.rapidapi.com/harem_altin/prices/23b4c2fb31a242d1eebc0df9b9b65e5e"),
                Headers =
            {
                { "x-rapidapi-key", _configuration["ApiKey:Key"] },
                { "x-rapidapi-host", "harem-altin-live-gold-price-data.p.rapidapi.com" },
            },
            };
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var values = JsonSerializer.Deserialize<GramGoldViewModel>(body,options);
                var result = values.data.FirstOrDefault(x => x.key == "GRAM ALTIN");

                return new ResultGoldİnfoViewModel
                {
                    key = result.key,
                    buy = result.buy,
                    sell = result.sell,
                    percent = result.percent,
                    arrow = result.arrow,
                    last_update = result.last_update
                };
            }
        }
    }
}
