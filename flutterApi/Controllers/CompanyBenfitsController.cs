using flutterApi.DTOs.Company_Benfits_;
using flutterApi.DTOs.Product;
using flutterApi.DTOs.ProductDto;
using flutterApi.Interfaces;
using flutterApi.Models;
using flutterApi.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace flutterApi.Controllers
{
    [Route("CompanyBenfits /[action]")]
    public class CompanyBenfitsController : Controller
    {
       private readonly ICompanyBenfitsService _companyBenfitsService;

        public CompanyBenfitsController(ICompanyBenfitsService companyBenfitsService)
        {
            _companyBenfitsService = companyBenfitsService;
        }
        [HttpPost]

        public async Task<IActionResult> AddCompanyBenfits([FromBody] CreateCompanyBenfitsDto model)
        {
            //if(model== null) { return null; }

            if (ModelState.IsValid)
            {
                var NewCompanyBenfit = await _companyBenfitsService.AddCompanyBenfits(model);

                if (NewCompanyBenfit == null) { return BadRequest("plz fill all Required fields"); }
                return Ok(NewCompanyBenfit);
            }
            return BadRequest(ModelState);
            //var user= _db.Users.Where(x=>x.Id==Newproduct.userId).FirstOrDefault();




        }
        [HttpGet]
        public async Task<IActionResult> GetCompanyBenfitById(int id)
        {

            var CompanyBenfit = await _companyBenfitsService.FindById(id);
            if (CompanyBenfit == null)
            {
                return NotFound("CompanyBenfit Not Found");
            }
            return Ok(CompanyBenfit);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCompanyBenfit()
        {
            var CompanyBenfits = await _companyBenfitsService.GetAll();
            if (CompanyBenfits != null || !CompanyBenfits.Any())
            {
                var result = CompanyBenfits.Adapt<IEnumerable<UpdateCompanyBenfitsDto>>().ToList(); ;


                return Ok(result);
            }
            var newCompanyBenfits = new List<IEnumerable<CreateCompanyBenfitsDto>>();
            return NotFound(newCompanyBenfits);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCompanyBenfit([FromBody] UpdateCompanyBenfitsDto model)
        {
            var CompanyBenfit = await _companyBenfitsService.FindById(model.CompanyBenfitsId);
            if (CompanyBenfit == null)
            {
                return NotFound(" this Company Benfit Not Found");
            }
            var UpdatedCompanyBenfit = await _companyBenfitsService.UpdateCompanyBenfits(model);
            if (UpdatedCompanyBenfit == null)
            {
                return BadRequest(" Company Benfit not updated");
            }
            else
            {
                return Ok(UpdatedCompanyBenfit);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCompanyBenfits([FromBody] UpdateCompanyBenfitsDto model)
        {
            var CompanyBenfit = await _companyBenfitsService.FindById(model.CompanyBenfitsId);
            if (CompanyBenfit == null)
            {
                return NotFound("CompanyBenfit Not Found");
            }
            var DeletedCompanyBenfits = await _companyBenfitsService.DeleteCompanyBenfits(model);

            return Ok("Company Benfits  Deleted");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCompanyBenfitById(int id)
        {

            var CompanyBenfit = await _companyBenfitsService.FindById(id);
            if (CompanyBenfit == null) { return NotFound("CompanyBenfit Not Found"); }
            await _companyBenfitsService.Delete(CompanyBenfit);
            await _companyBenfitsService.CommitChanges();
            return Ok("CompanyBenfits Deleted");
        }

    }
}
