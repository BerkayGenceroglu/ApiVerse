using ApiVerse.Api.Abstract.SocialMediaAbstracts;
using ApiVerse.Api.Models.SocialMediaModels;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace ApiVerse.Api.Services.SocialMediaService
{
    public class YoutubeService: IYoutubeService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public YoutubeService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<YoutubeVideoModel> Get5PopularVideosByTrendAsync()
        {
           
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://youtube-v311.p.rapidapi.com/videos/?part=snippet%2CcontentDetails%2Cstatistics&chart=mostPopular&regionCode=TR&maxResults=5"),
                Headers =
                {
                    { "x-rapidapi-key", _configuration["ApiKey:Key"]  },
                    { "x-rapidapi-host", "youtube-v311.p.rapidapi.com" },
                },
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<YoutubeVideoModel>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                var oneMonthAgo = DateTime.UtcNow.AddMonths(-1);
                apiResponse.items = apiResponse.items
                    .Where(x => x.snippet.publishedAt >= oneMonthAgo)
                    .Take(5)
                    .ToArray();
                return apiResponse;
            }
        }
    }
}
