using ApiVerse.Api.Models.SocialMediaModels;

namespace ApiVerse.Api.Abstract.SocialMediaAbstracts
{
    public interface IRedditService
    {
        Task<IEnumerable<RedditPostModel.PostData>> GetPostsBySubredditAsync(string subreddit, string sort = "hot");

    }
}
