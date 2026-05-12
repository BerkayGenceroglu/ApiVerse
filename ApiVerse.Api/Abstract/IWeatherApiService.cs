using ApiVerse.Api.Models.WeatherModels;

namespace ApiVerse.Api.Abstract
{
    public interface IWeatherApiService
    {
         Task<WeatherResponse> GetWeatherAsync(string cityName);
    }
}
