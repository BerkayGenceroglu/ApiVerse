using ApiVerse.Api.Models.SocialMediaModels;

namespace ApiVerse.Api.Abstract.SocialMediaAbstracts
{
    public interface IYoutubeService
    {
        Task<YoutubeVideoModel> Get5PopularVideosByTrendAsync();
    }
}
