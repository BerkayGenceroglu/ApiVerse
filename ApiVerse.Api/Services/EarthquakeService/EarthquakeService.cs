using ApiVerse.Api.Abstract.EarthquakeAbstracts;
using ApiVerse.Api.Models.EarthquakeModels;
using System.Text.Json;

namespace ApiVerse.Api.Services.EarthquakeService
{
    public class EarthquakeService : IEarthquakeService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _apiKey;
        private readonly string _apiHost;

        private const string BaseUrl = "https://canli-deprem-turkiye-live-earthquakes.p.rapidapi.com/api/v1/turkey/earthquake/latest";

        private static readonly Dictionary<string, (double lat, double lon)> TurkishCities = new(StringComparer.OrdinalIgnoreCase)
        {
            { "adana", (37.0000, 35.3213) },
            { "adıyaman", (37.7648, 38.2786) },
            { "afyon", (38.7507, 30.5567) },
            { "ağrı", (39.7191, 43.0503) },
            { "amasya", (40.6499, 35.8353) },
            { "ankara", (39.9334, 32.8597) },
            { "antalya", (36.8969, 30.7133) },
            { "artvin", (41.1828, 41.8183) },
            { "aydın", (37.8560, 27.8416) },
            { "balıkesir", (39.6484, 27.8826) },
            { "bilecik", (40.1506, 29.9792) },
            { "bingöl", (38.8854, 40.4983) },
            { "bitlis", (38.3938, 42.1232) },
            { "bolu", (40.7359, 31.6069) },
            { "burdur", (37.7204, 30.2906) },
            { "bursa", (40.1885, 29.0610) },
            { "çanakkale", (40.1553, 26.4142) },
            { "çankırı", (40.6013, 33.6134) },
            { "çorum", (40.5506, 34.9556) },
            { "denizli", (37.7765, 29.0864) },
            { "diyarbakır", (37.9144, 40.2306) },
            { "edirne", (41.6818, 26.5623) },
            { "elazığ", (38.6810, 39.2264) },
            { "erzincan", (39.7500, 39.5000) },
            { "erzurum", (39.9043, 41.2679) },
            { "eskişehir", (39.7767, 30.5206) },
            { "gaziantep", (37.0662, 37.3833) },
            { "giresun", (40.9128, 38.3895) },
            { "gümüşhane", (40.4386, 39.4814) },
            { "hakkari", (37.5744, 43.7408) },
            { "hatay", (36.4018, 36.3498) },
            { "ısparta", (37.7648, 30.5566) },
            { "mersin", (36.8000, 34.6333) },
            { "istanbul", (41.0082, 28.9784) },
            { "izmir", (38.4192, 27.1287) },
            { "kars", (40.6013, 43.0975) },
            { "kastamonu", (41.3887, 33.7827) },
            { "kayseri", (38.7312, 35.4787) },
            { "kırklareli", (41.7333, 27.2167) },
            { "kırşehir", (39.1425, 34.1709) },
            { "kocaeli", (40.8533, 29.8815) },
            { "konya", (37.8746, 32.4932) },
            { "kütahya", (39.4167, 29.9833) },
            { "malatya", (38.3552, 38.3095) },
            { "manisa", (38.6191, 27.4289) },
            { "kahramanmaraş", (37.5858, 36.9371) },
            { "mardin", (37.3212, 40.7245) },
            { "muğla", (37.2153, 28.3636) },
            { "muş", (38.9462, 41.7539) },
            { "nevşehir", (38.6939, 34.6857) },
            { "niğde", (37.9667, 34.6833) },
            { "ordu", (40.9862, 37.8797) },
            { "rize", (41.0201, 40.5234) },
            { "sakarya", (40.7569, 30.3781) },
            { "samsun", (41.2867, 36.3300) },
            { "siirt", (37.9333, 41.9500) },
            { "sinop", (42.0231, 35.1531) },
            { "sivas", (39.7477, 37.0179) },
            { "tekirdağ", (40.9833, 27.5167) },
            { "tokat", (40.3167, 36.5500) },
            { "trabzon", (41.0015, 39.7178) },
            { "tunceli", (39.1079, 39.5479) },
            { "şanlıurfa", (37.1591, 38.7969) },
            { "uşak", (38.6823, 29.4082) },
            { "van", (38.4891, 43.4089) },
            { "yozgat", (39.8181, 34.8147) },
            { "zonguldak", (41.4564, 31.7987) },
            { "aksaray", (38.3687, 34.0370) },
            { "bayburt", (40.2552, 40.2249) },
            { "karaman", (37.1759, 33.2287) },
            { "kırıkkale", (39.8468, 33.5153) },
            { "batman", (37.8812, 41.1351) },
            { "şırnak", (37.5164, 42.4611) },
            { "bartın", (41.6344, 32.3375) },
            { "ardahan", (41.1105, 42.7022) },
            { "ığdır", (39.9167, 44.0333) },
            { "yalova", (40.6500, 29.2667) },
            { "karabük", (41.2061, 32.6204) },
            { "kilis", (36.7184, 37.1212) },
            { "osmaniye", (37.0742, 36.2464) },
            { "düzce", (40.8438, 31.1565) },
        };

        public EarthquakeService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _apiKey = _configuration["ApiKey:Key"];
            _apiHost = "canli-deprem-turkiye-live-earthquakes.p.rapidapi.com";
        }

        private HttpRequestMessage BuildRequest(string url)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url)
            };
            request.Headers.Add("x-rapidapi-key", _apiKey);
            request.Headers.Add("x-rapidapi-host", _apiHost);
            return request;
        }

        public async Task<ResultEarthquakeModel> GetLiveEarthquakesAsync()
        {
            var request = BuildRequest(BaseUrl);
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ResultEarthquakeModel>(json);
        }


        public async Task<List<ResultEarthquakeModel.EarthquakeEvent>> GetNearbyEarthquakesAsync(string city, double radiusKm)
        {
            if (!TurkishCities.TryGetValue(city.Trim(), out var coords))
                return new List<ResultEarthquakeModel.EarthquakeEvent>();

            var result = await GetLiveEarthquakesAsync();
            if (result?.events == null)
                return new List<ResultEarthquakeModel.EarthquakeEvent>();

            return result.events
                .Where(e => e.preferred_data?.location != null &&
                            CalculateDistance(
                                coords.lat, coords.lon,
                                e.preferred_data.location.lat,
                                e.preferred_data.location.lon
                            ) <= radiusKm)
                .OrderByDescending(e => e.preferred_data.magnitude)
                .ToList();
        }

        private double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371;
            var dLat = (lat2 - lat1) * Math.PI / 180;
            var dLon = (lon2 - lon1) * Math.PI / 180;
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(lat1 * Math.PI / 180) * Math.Cos(lat2 * Math.PI / 180) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            return R * 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        }
    }
}