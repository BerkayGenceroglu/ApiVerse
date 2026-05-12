using ApiVerse.Api.Models.ExchangeModels;

namespace ApiVerse.Api.Abstract.ExchangeAbstracts
{
    public interface IMoneyService
    {
        Task<CurrencyRateViewModel> GetCurrencyRateAsync();
    }
}
