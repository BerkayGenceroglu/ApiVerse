using ApiVerse.Api.Abstract.SocialMediaAbstracts;
using ApiVerse.Api.Models.SocialMediaModels;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ApiVerse.Api.Services.SocialMediaService
{
    public class SpotifyService : ISpotifyService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;

        public SpotifyService(IConfiguration config, HttpClient client)
        {
            _config = config;
            _client = client;
        }

        public async Task<List<SpotifySongDto>> Get5PopularTracksByTrendAsync()
        {
            // API Anahtarını kontrol et (Hata almamak için)
            var apiKey = _config["ApiKey:Key"];
            if (string.IsNullOrEmpty(apiKey))
            {
                // Loglama yapılabilir
                return new List<SpotifySongDto>();
            }

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://spotify81.p.rapidapi.com/playlist_tracks?id=37i9dQZEVXbIVYVBNw9D5K&offset=0&limit=20"),
                Headers =
                {
                    { "x-rapidapi-key", apiKey },
                    { "x-rapidapi-host", "spotify81.p.rapidapi.com" },
                },
            };

            try
            {
                using (var response = await _client.SendAsync(request))
                {
                    // Başarılı kod gelmediyse (401, 403, 429 vb.) fırlatmak yerine güvenli çıkış yapalım
                    if (!response.IsSuccessStatusCode)
                    {
                        return new List<SpotifySongDto>();
                    }

                    var body = await response.Content.ReadAsStringAsync();

                    // JSON kontrolü: Eğer body "{" ile başlamıyorsa hatalıdır (S harfi hatası burası için önlem)
                    if (string.IsNullOrWhiteSpace(body) || !body.Trim().StartsWith("{"))
                    {
                        return new List<SpotifySongDto>();
                    }

                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var spotifyData = JsonSerializer.Deserialize<SpotifyViewModel>(body, options);

                    if (spotifyData?.items == null)
                    {
                        return new List<SpotifySongDto>();
                    }

                    return spotifyData.items
                        .Where(x => x.track != null)
                        .Select(x => new SpotifySongDto
                        {
                            SongName = x.track.name ?? "Bilinmiyor",
                            ArtistName = x.track.artists?.FirstOrDefault()?.name ?? "Bilinmeyen Sanatçı",
                            ImageUrl = x.track.album?.images?.FirstOrDefault()?.url ?? "/images/no-image.png"
                        })
                        .Take(6) // İstediğin miktar (6 popüler parça)
                        .ToList();
                }
            }
            catch (Exception)
            {
                // Hata durumunda uygulamanın çökmemesi için boş liste dönüyoruz
                return new List<SpotifySongDto>();
            }
        }
    }
}