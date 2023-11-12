using flutterApi.DTOs.Medical.PlacesOfTreatmentDetails;
using flutterApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace flutterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceOfTreatmentDetailsController : ControllerBase
    {
        private readonly IPlaceOfTreatmentDetailsService _placeOfTreatmentDetailsService;

        public PlaceOfTreatmentDetailsController(IPlaceOfTreatmentDetailsService placeOfTreatmentDetailsService)
        {
            _placeOfTreatmentDetailsService = placeOfTreatmentDetailsService;
        }
        [HttpPost("AddPlaceOfTreatmentDetails")]
        public async Task<IActionResult> AddPlaceOfTreatmentDetails(CreatePlaceOfTreatmentDetailsDto model)
        {
            var result = await _placeOfTreatmentDetailsService.AddPlaceOfTreatmentDetails(model);
            if (result.message != string.Empty || result.placeOfTreatmentDetails == null)
            {
                return BadRequest(result.message);
            }
            return Ok(result.placeOfTreatmentDetails);
        }

        [HttpGet("GetDetailsOfPlaceOfTreatment")]
        public async Task<IActionResult> GetDetailsOfPlaceOfTreatment(int id)
        {
            var result= await _placeOfTreatmentDetailsService.GetDetailsOfOnePlaceTreatment(id);
            if(result.message!=string.Empty||result.placeOfTreatmentDetails.Count()==0)
            {
                return NotFound();
            }
            return Ok(result.placeOfTreatmentDetails);
        }
        [HttpGet("GetDetailsOfOnePlaceTreatmentByType")]
        public async Task<IActionResult> GetDetailsOfOnePlaceTreatmentByType(int Placeid, int TypeId)
        {
         
            var result = await _placeOfTreatmentDetailsService.GetDetailsOfOnePlaceTreatmentByType(Placeid, TypeId);
            if(result.Message!=string.Empty||result.NameAndStatus.Count()==0)
            {
                return BadRequest(result.Message);

            }
           
            return Ok(result.NameAndStatus);
        }
    }
}
