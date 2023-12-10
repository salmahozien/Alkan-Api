using flutterApi.DTOs.Medical.MedicalPricingDataDtos;
using flutterApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace flutterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalPricingDataController : ControllerBase
    {
        private readonly IMedicalPricingDataService _medicalPricingService;

        public MedicalPricingDataController(IMedicalPricingDataService medicalPricingService)
        {
            _medicalPricingService = medicalPricingService;
        }

        [HttpPost("AddMedicalPricingData")]
        public async Task<IActionResult> AddMedicalPricingData(CreateMedicalPricingDataDto model)
        {
            var result= await _medicalPricingService.AddMedicalPricingData(model);
            if (result.Message != string.Empty || result.MedicalPricingData == null)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.MedicalPricingData);
        }
    }
}
