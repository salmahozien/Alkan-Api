using flutterApi.DTOs.PersonalAccident.Company;
using flutterApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace flutterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonlAccidentCompanyController : ControllerBase
    {
        private readonly IPersonalAccidentCompanyService _personalAccidentCompanyService;

        public PersonlAccidentCompanyController(IPersonalAccidentCompanyService personalAccidentCompanyService)
        {
           _personalAccidentCompanyService = personalAccidentCompanyService;
        }
        [HttpPost("AddPersonalAccidentCompany")]
        public async Task<IActionResult>AddPersonalAccidentCompany(CreatePersonalAccidentCompany model)
        {
            var result= await _personalAccidentCompanyService.AddCompany(model);
            if(result.Message!=string.Empty|| result.PersonalAccidentCompany == null)
            {
               return BadRequest(result.Message);
            }
            return Ok(result.PersonalAccidentCompany);
        }
        [HttpGet("GetAllPersonalAccidentCompany")]
        public async Task<IActionResult> GetAllCompanies()
        {
            var AllCompanies = await _personalAccidentCompanyService.GetAll();
            return Ok(AllCompanies);
        }
    }
}
