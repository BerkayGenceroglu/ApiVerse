using ApiVerse.Api.Abstract;
using ApiVerse.Api.Abstract.SocialMediaAbstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVerse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly IYoutubeService _youtubeService;
        private readonly ISpotifyService _spotifyService;
        private readonly IRedditService _redditService;

        public SocialMediaController(IYoutubeService youtubeService, ISpotifyService spotifyService, IRedditService redditService)
        {
            _youtubeService = youtubeService;
            _spotifyService = spotifyService;
            _redditService = redditService;
        }

        [HttpGet("youtube/popular-videos")]
        public async Task<IActionResult> Get5PopularVideosByTrend()
        {
            var result = await _youtubeService.Get5PopularVideosByTrendAsync();
            return Ok(result);
        }

        [HttpGet("spotify/popular-tracks")]
        public async Task<IActionResult> Get5PopularTracksByTrend()
        {
            var result = await _spotifyService.Get5PopularTracksByTrendAsync();
            return Ok(result);
        }

        [HttpGet("reddit/trending-posts")]
        public async Task<IActionResult> Get5TrendingPosts()
        {
            var result = await _redditService.GetPostsBySubredditAsync("programming");
            return Ok(result);
        }
    }
}
