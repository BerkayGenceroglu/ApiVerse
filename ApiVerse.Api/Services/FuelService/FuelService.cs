using ApiVerse.Api.Abstract.FuelAbstracts;
using ApiVerse.Api.Models.FuelModels;
using System.Text.Json;

namespace ApiVerse.Api.Services.FuelService
{
    public class FuelService : IFuelPriceService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ICurrencyService _currencyService;

        public FuelService(HttpClient httpClient, IConfiguration configuration, ICurrencyService currencyService)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _currencyService = currencyService;
        }

        public async Task<FuelPriceResponse.FuelPrice> GetTurkeyFuelPricesAsync()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://gas-price.p.rapidapi.com/europeanCountries"),
                Headers =
                {
                    { "x-rapidapi-key", _configuration["ApiKey:Key"] },
                    { "x-rapidapi-host", "gas-price.p.rapidapi.com" },
                },
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<FuelPriceResponse>(body, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });

                var turkey = data?.Result?.FirstOrDefault(r => r.Country == "Turkey");

                if (turkey == null) return null;

                // EUR → TRY çevir
                var eurRate = await _currencyService.GetEurToTryRateAsync();

                turkey.Gasoline = ConvertToTry(turkey.Gasoline, eurRate);
                turkey.Diesel = ConvertToTry(turkey.Diesel, eurRate);
                turkey.Lpg = ConvertToTry(turkey.Lpg, eurRate);
                turkey.Currency = "TRY";

                return turkey;
            }
        }

        private string ConvertToTry(string euroPrice, decimal rate)
        {
            if (string.IsNullOrEmpty(euroPrice) || euroPrice == "-") return "-";
            var price = decimal.Parse(euroPrice.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture);
            return (price * rate).ToString("F2");
        }
    }
}