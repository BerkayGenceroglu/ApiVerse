using ApiVerse.Api.Abstract.ExchangeAbstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiVerse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController : ControllerBase
    {
        private readonly IGoldService _goldService;
        private readonly IMoneyService _moneyService;
        private readonly IBitcoinService _bitcoinService;
        public ExchangeController(IGoldService goldService, IMoneyService moneyService, IBitcoinService bitcoinService)
        {
            _goldService = goldService;
            _moneyService = moneyService;
            _bitcoinService = bitcoinService;
        }

        [HttpGet("gold")]
        public async Task<IActionResult> GetGoldPrice()
        {
            var goldPrice = await _goldService.GetGoldİnformation();
            return Ok(goldPrice);
        }
        [HttpGet("currency")]
        public async Task<IActionResult> GetCurrencyRate()
        {
            var currencyRate = await _moneyService.GetCurrencyRateAsync();
            return Ok(currencyRate);
        }
        [HttpGet("Bitcoin")]
        public async Task<IActionResult> GetBitcoinPrice()
        {
            var bitcoinPrice = await _bitcoinService.GetBitcoinInformation();
            return Ok(bitcoinPrice);
        }
    }
}
