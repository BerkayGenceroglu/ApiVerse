using ApiVerse.Api.Models.SocialMediaModels;

namespace ApiVerse.UI.Models
{
    public class SocialMediaTrendsViewModel
    {
        public YoutubeVideoModel Youtube { get; set; }
        public List<SpotifySongDto> Spotify { get; set; }
        public IEnumerable<RedditPostModel.PostData> Reddit { get; set; }
    }
}
