using ApiVerse.Api.Abstract.EarthquakeAbstracts;
using Microsoft.AspNetCore.Mvc;

namespace ApiVerse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EarthquakeController : ControllerBase
    {
        private readonly IEarthquakeService _earthquakeService;

        public EarthquakeController(IEarthquakeService earthquakeService)
        {
            _earthquakeService = earthquakeService;
        }

        // GET api/earthquake/live
        [HttpGet("live")]
        public async Task<IActionResult> GetLiveEarthquakes()
        {
            var result = await _earthquakeService.GetLiveEarthquakesAsync();
            return Ok(result);
        }

       

        // GET api/earthquake/nearby?latitude=41.01&longitude=28.97&radiusKm=100
        [HttpGet("nearby")]
        public async Task<IActionResult> GetNearbyEarthquakes(
           [FromQuery] string city,
           [FromQuery] double radiusKm = 300)
        {
            if (string.IsNullOrWhiteSpace(city))
                return BadRequest("Şehir adı boş olamaz.");

            var result = await _earthquakeService.GetNearbyEarthquakesAsync(city, radiusKm);

            if (result == null || !result.Any())
                return NotFound($"'{city}' için deprem bulunamadı veya şehir adı tanınmadı.");

            return Ok(result);
        }
    }
}