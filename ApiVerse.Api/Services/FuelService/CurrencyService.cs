using ApiVerse.Api.Abstract.FuelAbstracts;
using System.Xml.Linq;

namespace ApiVerse.Api.Services.FuelService
{
    public class CurrencyService : ICurrencyService
    {
        private readonly HttpClient _httpClient;

        public CurrencyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<decimal> GetEurToTryRateAsync()
        {
            var response = await _httpClient.GetStringAsync("https://www.tcmb.gov.tr/kurlar/today.xml");

            var xml = XDocument.Parse(response);

            var eurRate = xml.Descendants("Currency")
                .FirstOrDefault(x => x.Attribute("CurrencyCode")?.Value == "EUR");

            var forexBuying = eurRate?.Element("ForexBuying")?.Value;

            return decimal.Parse(forexBuying, System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
