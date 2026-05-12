using ApiVerse.Api.Models.MovieModels;

namespace ApiVerse.Api.Abstract
{
    public interface IMovieService
    {
        Task<ResultMovieDto.Item[]> GetAllMoviesAsync(string title);
    }
}
