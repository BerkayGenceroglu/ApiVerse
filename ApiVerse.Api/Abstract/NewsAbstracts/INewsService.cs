using ApiVerse.Api.Models.NewsModels;

namespace ApiVerse.Api.Abstract.NewsAbstracts
{
    public interface INewsService
    {
        Task<ResultNewsResult> SearchNewsAsync(string query, int max = 6);
    }
}
