using ApiVerse.UI.Models;
using ApiVerse.UI.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiVerse.UI.Controllers
{
    public class FootballController : Controller
    {
        private readonly FootballClientService _footballClientService;
        private readonly PredictionService _predictionService;

        public FootballController(FootballClientService footballClientService, PredictionService predictionService)
        {
            _footballClientService = footballClientService;
            _predictionService = predictionService;
        }

        public async Task<IActionResult> Fixtures()
        {
            var viewModel = new WeeklyFixturesViewModel
            {
                LastWeek = await _footballClientService.GetLastWeekAsync(),
                ThisWeek = await _footballClientService.GetThisWeekAsync(),
                NextWeek = await _footballClientService.GetNextWeekAsync()
            };

            return View(viewModel);
        }
        public async Task<IActionResult> Predictions()
        {
            var predictions = await _predictionService.GetPredictionsAsync();
            return View(predictions);
        }

    }
}
