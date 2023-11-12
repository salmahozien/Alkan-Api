using flutterApi.DTOs.PersonalImagesUrls;
using flutterApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace flutterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalImagesUrlController : ControllerBase
    {
        private readonly IPersonalImagesUrlService _personalImagesUrlService;

        public PersonalImagesUrlController(IPersonalImagesUrlService personalImagesUrlService)
        {
            _personalImagesUrlService = personalImagesUrlService;
        }


        [HttpPost("AddPersonalImages")]
        //  public async Task<IActionResult> addPersonalImages(IFormFile IdCard,IFormFile PersonalDrivingLicense,IFormFile CarLicense,string UserId)
        public async Task<IActionResult> addPersonalImages([FromForm]personalImagesUrlDtos model) {
        
                var PersonalImages = await _personalImagesUrlService.AddPersonalImagesUrl(model);
            if(PersonalImages.Message!=string.Empty|| PersonalImages.personalImage==null) {
                return BadRequest(PersonalImages.Message);
            }
            return Ok(PersonalImages.personalImage);
            
        }
    }
}
