using flutterApi.DTOs.InsuranceRequests;
using flutterApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Core;

namespace flutterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceRequestController : ControllerBase
    {
        private readonly IInsuranceRequestService _insuranceRequestService;

        public InsuranceRequestController(IInsuranceRequestService insuranceRequestService)
        {
            _insuranceRequestService = insuranceRequestService;
        }

        [HttpPost("AddInsuranceRequest")]
        public async Task<IActionResult> AddInsuranceRequest(InsuranceRequestDto model)
        {
            var request= await _insuranceRequestService.AddInsuranceRequest(model);
            if(request.Message!=string.Empty||request.InsuranceRequest==null)
            {
                return BadRequest(request.Message);
            }
            return Ok(request.InsuranceRequest);
        }


        [HttpGet("GetInsuranceRequestById")]
        public async Task<IActionResult> GetInsuranceRequestById(int id)
        {
            var request = await _insuranceRequestService.GetInsuranceRequestById(id);
            if (request.Message != string.Empty || request.InsuranceRequest == null)
            {
                return BadRequest(request.Message);
            }
            return Ok(request.InsuranceRequest);
        }
        [HttpGet("GetAllInsuranceRequest")]
        public async Task<IActionResult> GetAllInsuranceRequest()
        {
            var insurance = await _insuranceRequestService.GetAll();
            if(insurance == null) { return BadRequest("no Insurance Request Found"); }
            return Ok(insurance);
        }
        [HttpPut ("EditInsuranceRequest")]
        public async Task<IActionResult> EditInsuranceRequest(UpdateInsuranceRequestDto model)
        {
            var insurance = await _insuranceRequestService.EditInsuranceRequest(model);
            if(insurance.Message!=string.Empty || insurance.InsuranceRequest == null)
            {
                return BadRequest(insurance.Message);
            }
            return Ok(insurance.InsuranceRequest);
        }
    }
}
