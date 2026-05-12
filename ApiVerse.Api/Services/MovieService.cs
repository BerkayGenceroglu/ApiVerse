using ApiVerse.Api.Abstract;
using ApiVerse.Api.Models.MovieModels;
using System.Text.Json;

namespace ApiVerse.Api.Services
{
    public class MovieService : IMovieService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public MovieService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<ResultMovieDto.Item[]> GetAllMoviesAsync(string searchQuery)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://tmdb-movies-and-tv-shows-api-by-apirobots.p.rapidapi.com/v1/tmdb?name={searchQuery}&page=1"),
                Headers =
                {
                    { "x-rapidapi-key", _configuration["ApiKey:Key"] },
                    { "x-rapidapi-host", "tmdb-movies-and-tv-shows-api-by-apirobots.p.rapidapi.com" },
                },
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<ResultMovieDto>(body, options);

                return  result?.items?
                         .Where(x => x.popularity > 20)
                         .Where(x => x.vote_average > 7)
                         .Where(x =>
                             x.title.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                             x.overview.Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
                         .DistinctBy(x => x.title)
                         .OrderByDescending(x => x.vote_average)
                         .Take(6)
                         .ToArray();
            }
        }
    }
}