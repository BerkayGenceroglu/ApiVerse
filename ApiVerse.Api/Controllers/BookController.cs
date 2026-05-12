using ApiVerse.Api.Abstract.BookAbstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiVerse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }


        [HttpGet("{query}")]
        public async Task<IActionResult> GetBooks(string query)
        {
            var books = await _bookService.SearchBooksAsync(query);
            return Ok(books);
        }
    }
}
