using ApiVerse.Api.Models.SocialMediaModels;

namespace ApiVerse.Api.Abstract.SocialMediaAbstracts
{
    public interface ISpotifyService
    {
        Task<List<SpotifySongDto>> Get5PopularTracksByTrendAsync();
    }
}
