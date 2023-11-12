using flutterApi.DTOs.Medical.HealthInsuranceTypes;
using flutterApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace flutterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyHealthInsuranceTypeController : ControllerBase
    {
        private readonly ICompanyHealthInsuranceTypesService _companyHealthInsuranceType;
        public CompanyHealthInsuranceTypeController(ICompanyHealthInsuranceTypesService companyHealthInsuranceType)
        {
            _companyHealthInsuranceType = companyHealthInsuranceType;
        }

        [HttpPost("AddMedicalInsuranceType")]
        public async Task<IActionResult> AddMedicalInsuranceType(CreateCompanyHealthInsuranceTypes model)
        {
            var result = await _companyHealthInsuranceType.addCompanyHealthInsuranceTypes(model);
            if (result.message != string.Empty || result.InsuranceTypes == null)
            {
                return BadRequest(result.message);
            }
            return Ok(result.InsuranceTypes);
        }
        [HttpGet("GetCompanyHealthInsuranceTypesByCompanyId")]
        public async Task<IActionResult> GetCompanyHealthInsuranceTypesByCompanyId(int id)
        {
            var result = await _companyHealthInsuranceType.GetCompanyHealthInsuranceTypesByCompanyId(id);
            if (result.message != string.Empty || result.InsuranceTypes == null)
            {
                return BadRequest(result.message);
            }
            return Ok(result.InsuranceTypes);
        }
        [HttpGet("GetTypesName")]
        public async Task<IActionResult> GetTypesName(int id)
        {
            var result = await _companyHealthInsuranceType.GetTypesNameForOneComapny(id);
            if (result.Message != string.Empty || result.Names.Count()==0)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Names);
        }
        
    }
}
