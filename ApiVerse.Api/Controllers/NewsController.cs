using ApiVerse.Api.Abstract.NewsAbstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVerse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet("{query}")]
        public async Task<IActionResult> GetNews(string query)
        {
            var news = await _newsService.SearchNewsAsync(query);
            return Ok(news);
        }
    }
}
