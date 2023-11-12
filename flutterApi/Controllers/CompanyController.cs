using flutterApi.DTOs.Company;
using flutterApi.DTOs.Product;
using flutterApi.DTOs.ProductDto;
using flutterApi.Interfaces;
using flutterApi.Models;
using flutterApi.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace flutterApi.Controllers
{
    [Route("Company/[action]")]
    public class CompanyController : Controller
    {
       private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCompany()
        {
            var Companies = await _companyService.GetAll();
            if (Companies != null || !Companies.Any())
            {
                var result = Companies.Adapt<IEnumerable<UpdateCompanyDto>>().ToList(); ;


                return Ok(result);
            }
            var newCompany= new List<IEnumerable<CreateCompanyDto>>();
            return NotFound(newCompany);

        }
        [HttpGet]
        public async Task<IActionResult> GetCompanyById( int id)
        {
            var Company = await _companyService.FindById(id);
            if (Company == null)
            {
                return NotFound("Company Not Found");
            }
            return Ok(Company);
        }
        [HttpPost]
        public async Task<IActionResult> AddCompany([FromBody]CreateCompanyDto Company)
        {
            if (ModelState.IsValid)
            {
                var NewCompany = await _companyService.AddCompany(Company);
                if (NewCompany == null) { return BadRequest(ModelState); }
                return Ok(NewCompany);
            }
            return BadRequest(ModelState);
        }

        /* [HttpPut]
         public async Task<IActionResult> UpdateCompany(UpdateCompanyDto dto)
         {
             var Company = await _companyService.FindById(dto.CompanyId);
             if (Company == null)
             {
                 return NotFound(" this Company Not Found");
             }
             var UpdatedCompany = await _companyService.UpdateCompany(Company);
             if (UpdatedCompany == null)
             {
                 return BadRequest(" Company not updated");
             }
             else
             {
                 return Ok(UpdatedCompany);
             }
         }*/
        [HttpDelete]
        public async Task<IActionResult> DeleteCompanyById( int id)
        {

            var Company = await _companyService.FindById(id);
            if (Company == null) { return NotFound("Company Not Found"); }
            await _companyService.Delete(Company);
            await _companyService.CommitChanges();
            return Ok(Company);
        }
        [HttpGet]
        public async Task<String> GetCompanyName(int id)
        {
            var Company= await _companyService.FindByIdWithData(id);
            if (Company == null) { return "no Company Found"; }
            var CompanyName = Company.CompanyName;
            return CompanyName;
        }



    }
}
