using flutterApi.DTOs.PersonalAccident.Limits;
using flutterApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace flutterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalAccidentLimitController : ControllerBase
    {
        private readonly IPersonalAccidentLimitService _personalAccidentLimitService;

        public PersonalAccidentLimitController(IPersonalAccidentLimitService personalAccidentLimitService)
        {
            _personalAccidentLimitService = personalAccidentLimitService;
        }
        [HttpPost("AddPersonalAccidentLimit")]
        public async Task<IActionResult> AddPersonalAccidentLimit(CreatePersonalAccidentLimit model)
        {
            var result=await _personalAccidentLimitService.AddPersonalAccidentLimit(model);
            if (result.Message != string.Empty || result.PersonalAccidentLimit == null)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.PersonalAccidentLimit);
        }
    }
}
