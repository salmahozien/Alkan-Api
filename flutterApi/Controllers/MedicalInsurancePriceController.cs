using flutterApi.DTOs.Medical.AgeLmit.MedicalInsurancePriceDto;
using flutterApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace flutterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalInsurancePriceController : ControllerBase
    {
        private readonly ImedicalInsurancePricesService _medicalInsurancePricesService;

        public MedicalInsurancePriceController(ImedicalInsurancePricesService medicalInsurancePricesService)
        {
            _medicalInsurancePricesService = medicalInsurancePricesService;
        }
        [HttpPost("AddMedicalInsurancePrice")]
        public async Task<IActionResult> AddMedicalInsurancePrice(CreateMedicalInsurancePriceDto dto)
        {
            var result = await _medicalInsurancePricesService.AddMedicalInsurancePrice(dto);
            if(result.Message!=string.Empty|| result.MedicalInsurancePrice == null)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpGet("GetMedicalInsurancePrice")]
       public async Task<IActionResult> GetMedicalInsurancePrice(int type, int age, int MedicalCompanyId,float Price)
        {
            var result = await _medicalInsurancePricesService.GetMedicalInsurancePrice(type,age,MedicalCompanyId, Price);
            if (result.Message != string.Empty || result.PriceAndPremium == null)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.PriceAndPremium);
        }
    }
}
