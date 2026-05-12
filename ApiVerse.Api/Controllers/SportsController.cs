using ApiVerse.Api.Abstract.FootballAbstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVerse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportsController : ControllerBase
    {
        private readonly IFootballService _footballService;

        public SportsController(IFootballService footballService)
        {
            _footballService = footballService;
        }
        [HttpGet("football/fixtures/lastweek")]
        public async Task<IActionResult> GetLastWeekFixtures()
        {
            var fixtures = await _footballService.GetLastWeekMatchesAsync();
            return Ok(fixtures);
        }

        [HttpGet("football/fixtures/thisweek")]
        public async Task<IActionResult> GetThisWeekFixtures()
        {
            var fixtures = await _footballService.GetThisWeekMatchesAsync();
            return Ok(fixtures);
        }

        [HttpGet("football/fixtures/nextweek")]
        public async Task<IActionResult> GetNextWeekFixtures()
        {
            var fixtures = await _footballService.GetNextWeekMatchesAsync();
            return Ok(fixtures);
        }
    }
}
