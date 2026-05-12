using ApiVerse.Api.Models.EarthquakeModels;

namespace ApiVerse.Api.Abstract.EarthquakeAbstracts
{
    public interface IEarthquakeService
    {
        Task<ResultEarthquakeModel> GetLiveEarthquakesAsync();
        Task<List<ResultEarthquakeModel.EarthquakeEvent>> GetNearbyEarthquakesAsync(string city, double radiusKm);
    }
}
