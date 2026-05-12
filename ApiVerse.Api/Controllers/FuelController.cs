using ApiVerse.Api.Abstract.FuelAbstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVerse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelController : ControllerBase
    {
        private readonly IFuelPriceService _fuelPriceService;

        public FuelController(IFuelPriceService fuelPriceService)
        {
            _fuelPriceService = fuelPriceService;
        }

        [HttpGet("TurkeyFuelPrice")]
        public async Task<IActionResult> Index()
        {
            var fuelPrices = await _fuelPriceService.GetTurkeyFuelPricesAsync();
            return Ok(fuelPrices);
        }
    }
}
