using ApiVerse.Api.Models.SocialMediaModels;
using ApiVerse.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ApiVerse.UI.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly ILogger<SocialMediaController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public SocialMediaController(ILogger<SocialMediaController> logger, IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> GetTrends()
        {
            var client = _httpClientFactory.CreateClient();

            var youtubeTask = client.GetAsync("https://localhost:7239/api/SocialMedia/youtube/popular-videos");
            var redditTask = client.GetAsync("https://localhost:7239/api/SocialMedia/reddit/trending-posts");
            var spotifyTask = client.GetAsync("https://localhost:7239/api/SocialMedia/spotify/popular-tracks");

            await Task.WhenAll(youtubeTask, redditTask,spotifyTask);

            var youtubeJson = await youtubeTask.Result.Content.ReadAsStringAsync();
            var redditJson = await redditTask.Result.Content.ReadAsStringAsync();
            var spotifyJson = await spotifyTask.Result.Content.ReadAsStringAsync();
            var model = new SocialMediaTrendsViewModel
            {
                Youtube = JsonConvert.DeserializeObject<YoutubeVideoModel>(youtubeJson),
                Reddit = JsonConvert.DeserializeObject<IEnumerable<RedditPostModel.PostData>>(redditJson) ,
                Spotify = JsonConvert.DeserializeObject<List<SpotifySongDto>>(spotifyJson)
            };

            return View(model);
        }
    }
}
