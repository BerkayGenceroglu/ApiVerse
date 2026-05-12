using ApiVerse.Api.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiVerse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieApiController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieApiController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet("{title}")]
        public async Task<IActionResult> GetAllMovies([FromRoute(Name = "title")] string subject)
        {
            var movies = await _movieService.GetAllMoviesAsync(subject);
            return Ok(movies);
        }
    }
}
