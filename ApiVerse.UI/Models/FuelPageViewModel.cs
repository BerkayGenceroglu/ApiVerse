using static ApiVerse.Api.Models.FuelModels.FuelPriceResponse;

namespace ApiVerse.UI.Models
{
    public class FuelPageViewModel
    {
        public FuelPrice FuelPrice { get; set; }
        public string AiComment { get; set; }
    }
}
