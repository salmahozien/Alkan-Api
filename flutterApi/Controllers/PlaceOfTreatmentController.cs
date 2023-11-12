using flutterApi.DTOs.Medical.PlacesOfTreatment;
using flutterApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace flutterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceOfTreatmentController : ControllerBase
    {
        private readonly IPlaceOfTreatmentService _placeOfTreatmentService;

        public PlaceOfTreatmentController(IPlaceOfTreatmentService placeOfTreatmentService)
        {
            _placeOfTreatmentService = placeOfTreatmentService;
        }
        [HttpPost("AddPlaceOfTreatment")]
        public async Task<IActionResult> AddPlaceOfTreatment(CreatePlaceOfTreatment model)
        {
            var result = await _placeOfTreatmentService.AddPlaceOfTreatment(model);
            if (result.Message != string.Empty || result.PlaceOfTreatment == null)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.PlaceOfTreatment);
        }

        [HttpGet("GetAllPlaceOfTretment")]
        public async Task<IActionResult> GetAllPlaceOfTretment()
        {
            var AllPlaces = await _placeOfTreatmentService.GetAll();
            if (AllPlaces.Count() == 0) { return NotFound("No Places Of Treatment Found!"); }
            else { return Ok(AllPlaces); }
        }
        [HttpGet("GetAllPlaceOfTreatmentForOneCompany")]
        public async Task<IActionResult> GetAllPlaceOfTreatmentForOneCompany( int CompanyId)
        {
            var result = await _placeOfTreatmentService.GetAllPlaceOfTreatmentByCompanyId(CompanyId);
            if (result.Message != string.Empty || result.PlaceOfTreatment.Count() == 0)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.PlaceOfTreatment);

        }
    }
}
