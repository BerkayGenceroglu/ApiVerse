using System.Text.Json;
using ApiVerse.Api.Abstract.SocialMediaAbstracts;
using ApiVerse.Api.Models.SocialMediaModels;

namespace ApiVerse.Api.Services
{
    public class RedditService : IRedditService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public RedditService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<IEnumerable<RedditPostModel.PostData>> GetPostsBySubredditAsync(string subreddit = "all", string sort = "hot")
        {
            // Eğer boş gelirse genel trendler için "all" kullanıyoruz
            var targetSubreddit = string.IsNullOrEmpty(subreddit) ? "all" : subreddit;

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://reddit34.p.rapidapi.com/getPostsBySubreddit?subreddit={targetSubreddit}&sort={sort}"),
                Headers =
                {
                    { "x-rapidapi-key", _configuration["ApiKey:Key"] },
                    { "x-rapidapi-host", "reddit34.p.rapidapi.com" },
                }
            };

            try
            {
                using var response = await _httpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                    return Enumerable.Empty<RedditPostModel.PostData>();

                var json = await response.Content.ReadAsStringAsync();

                // "S" harfi hatası için JSON kontrolü
                if (string.IsNullOrWhiteSpace(json) || !json.Trim().StartsWith("{"))
                    return Enumerable.Empty<RedditPostModel.PostData>();

                var redditResponse = JsonSerializer.Deserialize<RedditPostModel>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var posts = redditResponse?.data?.posts
                ?.Select(p => p.data)
                .OrderByDescending(d => d.score)
                .Take(6)
                .ToList();

                return posts ?? Enumerable.Empty<RedditPostModel.PostData>();
            }
            catch (Exception)
            {
                return Enumerable.Empty<RedditPostModel.PostData>();
            }
        }
    }
}