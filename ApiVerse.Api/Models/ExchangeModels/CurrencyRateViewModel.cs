namespace ApiVerse.Api.Models.ExchangeModels
{
    public class CurrencyRateViewModel
    {
        public string Base { get; set; }
        public decimal USD { get; set; } 
        public decimal EUR { get; set; }  
        public string LastUpdate { get; set; }
    }
}
