using ApiVerse.Api.Models.NewsModels;
using Microsoft.AspNetCore.Mvc;

namespace ApiVerse.UI.Controllers
{
    public class NewsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NewsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> NewsPage(string query = "Türkiye", int max = 10)
        {
            var result =  _httpClientFactory.CreateClient();

            var response = await result.GetAsync($"https://localhost:7239/api/news/{query}");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadAsStringAsync();
                var newsList = System.Text.Json.JsonSerializer.Deserialize<ResultNewsResult>(value);
                return View(newsList);
            }
            return View(null);
        }
    }
}
