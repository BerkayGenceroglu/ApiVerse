namespace ApiVerse.Api.Abstract.FuelAbstracts
{
    public interface ICurrencyService
    {
        Task<decimal> GetEurToTryRateAsync();
    }
}
