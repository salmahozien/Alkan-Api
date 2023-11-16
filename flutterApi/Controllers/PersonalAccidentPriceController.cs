using flutterApi.DTOs.PersonalAccident.Price;
using flutterApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace flutterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalAccidentPriceController : ControllerBase
    {
        private readonly IPersonalAccidentPriceService _personalAccidentPriceService;

        public PersonalAccidentPriceController(IPersonalAccidentPriceService personalAccidentPriceService)
        {
            _personalAccidentPriceService = personalAccidentPriceService;
        }
        [HttpPost("AddPrice")]
        public async Task<IActionResult> AddPrice(CreatePersonalAccidentPrice model)
        {
            var result= await _personalAccidentPriceService.AddPersonalAccidentPrice(model);
            if (result.Message != string.Empty || result.PersonalAccidentPrice == null)
            {
                return BadRequest(result.Message);

            }
            return Ok(result.PersonalAccidentPrice);
        }
        [HttpGet("GetPremiumAndTotalInstallment")]
        public async Task<IActionResult> GetPremiumAndTotalInstallment(int personalAccidentPriceId)
        {
            var result = await _personalAccidentPriceService.GetPremiumAndTotalInstallment(personalAccidentPriceId);
                  if (result.Message != string.Empty || result.permiumAndTotal == null)
            {
                return BadRequest(result.Message);

            }
            return Ok(result.permiumAndTotal);
        }
    }
}
