using ApiVerse.Api.Models.ExchangeModels;

namespace ApiVerse.UI.Models
{
    public class ExchangeViewModel
    {
        public ResultGoldİnfoViewModel ResultGoldViewModel { get; set; }
        public CurrencyRateViewModel  CurrencyRateViewModel { get; set; }
        public BitcoinValueViewModel  BitcoinValueViewModel { get; set; }
        public string AiAnalysis { get; set; }
    }
}
