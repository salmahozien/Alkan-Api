using flutterApi.DTOs.Home.HomeCompaniesDto;
using flutterApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace flutterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeCompanyController : ControllerBase
    {
        private readonly IHomeCompaniesService _homeCompaniesService;

        public HomeCompanyController(IHomeCompaniesService homeCompaniesService)
        {
            _homeCompaniesService = homeCompaniesService;
        }
        [HttpPost("AddHomeCompany")]
        public async Task<IActionResult>AddHomeCompany(CreateHomeCompanyDto model)
        {
            var result= await _homeCompaniesService.AddHomeCompany(model);
            if(result.Message!=string.Empty|| result.homeCompany == null)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.homeCompany);
        }
        [HttpGet("GetAllHomeCompanies")]
        public async Task<IActionResult> GetAllCompanies()
        {
            var AllCompanies = await _homeCompaniesService.GetAll();
            if (AllCompanies.Count() == 0)
            {
                return Ok("No Company Added");
            }
            return Ok(AllCompanies);
        }
    }
}
