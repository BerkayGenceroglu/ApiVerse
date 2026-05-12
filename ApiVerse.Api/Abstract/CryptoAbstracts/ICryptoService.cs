using static ApiVerse.Api.Models.CryptoModels.CryptoResponseViewModel;

namespace ApiVerse.Api.Abstract.CryptoAbstracts
{
    public interface ICryptoService
    {
        Task<List<CryptoResult>> GetTopCryptosAsync();
    }
}
