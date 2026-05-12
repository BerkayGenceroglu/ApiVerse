using static ApiVerse.Api.Models.FuelModels.FuelPriceResponse;

namespace ApiVerse.Api.Abstract.FuelAbstracts
{
    public interface IFuelPriceService
    {
        Task<FuelPrice> GetTurkeyFuelPricesAsync();
    }
}
