using ApiVerse.Api.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVerse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherApiController : ControllerBase
    {
        private readonly IWeatherApiService _weatherApiService;

        public WeatherApiController(IWeatherApiService weatherApiService)
        {
            _weatherApiService = weatherApiService;
        }

        [HttpGet("{cityName}")]
        public async Task<IActionResult> GetWeather(string cityName)
        {
            var weatherData = await _weatherApiService.GetWeatherAsync(cityName);
            return Ok(weatherData);
        }
    }
}
