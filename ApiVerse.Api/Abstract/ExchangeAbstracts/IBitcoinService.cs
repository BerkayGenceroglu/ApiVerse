using ApiVerse.Api.Models.ExchangeModels;

namespace ApiVerse.Api.Abstract.ExchangeAbstracts
{
    public interface IBitcoinService
    {
       Task<BitcoinValueViewModel> GetBitcoinInformation();
    }
}
