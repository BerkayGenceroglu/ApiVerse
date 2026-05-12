using ApiVerse.Api.Models.ExchangeModels;

namespace ApiVerse.Api.Abstract.ExchangeAbstracts
{
    public interface IGoldService 
    {
        Task<ResultGoldİnfoViewModel> GetGoldİnformation();
    }
}
