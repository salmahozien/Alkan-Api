using flutterApi.DTOs.Home.HomeLimitsDTOS;
using flutterApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace flutterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeLimitsController : ControllerBase
    {
        private readonly IHomeLimitsService _homeLimitsService;

        public HomeLimitsController(IHomeLimitsService homeLimitsService)
        {
            _homeLimitsService = homeLimitsService;
        }
        [HttpPost("AddHmeLimits")]
        public async Task<IActionResult>AddLimit(CreateHomeLimitsDto model)
        {
            var result=await _homeLimitsService.AddHomeLimits(model);
            if (result.Message != string.Empty)
            { return BadRequest(result.Message); }
                return Ok(result.HomeLimits);

        }
    }
}
