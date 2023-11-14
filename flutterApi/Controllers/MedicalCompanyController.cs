using flutterApi.DTOs.Medical.MedicalCompanies;
using flutterApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace flutterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalCompanyController : ControllerBase
    {
        private readonly IMedicalCompanyService _mediicalCompanyService;

        public MedicalCompanyController(IMedicalCompanyService mediicalCompanyService)
        {
            _mediicalCompanyService = mediicalCompanyService;
        }

        [HttpPost("AddMedicalCompany")]
        public async Task<IActionResult> AddMedicalCompany(CreateMedicalCompanyDto model)
        {
            var result = await _mediicalCompanyService.AddMedicalCompany(model);
            if (result.message != string.Empty || result.MedicalCompany == null)
            {
                return BadRequest(result.message);

            }
            return Ok(result.MedicalCompany);
        }
        [HttpGet("GetAllMedicalCompanies")]
        public async Task<IActionResult> GetAllMedicalCompanies()
        {
            var AllMedicalCompanies = await _mediicalCompanyService.GetAll();
            if (AllMedicalCompanies.Count() == 0)
            {
                return Ok("No Company Added");
            }
            return Ok(AllMedicalCompanies);
        }
        [HttpGet("GetMedicalCompanyById")]
        public async Task<IActionResult> GetMedicalCompanyById(int id)
        {
            var result = await _mediicalCompanyService.FindMedicalCompanyById(id);
            if (result.message != string.Empty || result.MedicalCompany == null)
            {
                return BadRequest(result.message);
            }
            return Ok(result.MedicalCompany);
        }
    }

}
