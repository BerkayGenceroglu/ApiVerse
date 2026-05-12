using ApiVerse.Api.Abstract.CryptoAbstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVerse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptoController : ControllerBase
    {
        private readonly ICryptoService _cryptoService;

        public CryptoController(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }
        [HttpGet("crypto")]
        public async Task<IActionResult> GetTopCryptos()
        {
            var result = await _cryptoService.GetTopCryptosAsync();
            return Ok(result);
        }
    }
}
