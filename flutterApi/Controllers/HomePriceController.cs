using flutterApi.DTOs.Home.HomePriceDtos;
using flutterApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace flutterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomePriceController : ControllerBase
    {
        private readonly IHomePriceService _homePriceService;

        public HomePriceController(IHomePriceService homePriceService)
        {
            _homePriceService = homePriceService;
        }

        [HttpPost("addHomePrice")]
        public async Task<IActionResult>AddHomePrice(CreateHomePriceDto model)
        {
            var result= await _homePriceService.AddHomePrice(model);
            if (result.Message != string.Empty || result.homePrice == null)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.homePrice);
        }
        [HttpGet("GetPermiumAndTotalInstallment")]
        public async Task<IActionResult> GetPermiumAndTotal(int HomePriceId)
        {
            var result = await _homePriceService.GetPremiumAndTotalInstallment(HomePriceId);
            if (result.Message != string.Empty || result.premiumAndTotal == null)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.premiumAndTotal);
        }
    }
}
