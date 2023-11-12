using flutterApi.DTOs.Company;
using flutterApi.DTOs.CompanyInfo;
using flutterApi.Enums;
using flutterApi.Interfaces;
using flutterApi.Models;
using flutterApi.Services;
using login.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Runtime.InteropServices;

namespace flutterApi.Controllers
{

    [Route("CompanyInfo/[action]")]
    public class CompanyInfoController : Controller
    {
        private readonly ICompanyInfoService _companyInfoService;
        private readonly ICompanyService _companyService;
        private readonly ICompanyBenfitsService _companyBenfitsService;
        private readonly IInsuranceService _insuranceService;
        ApplicationDBContext _context;

        public CompanyInfoController(ICompanyInfoService companyInfo, ICompanyService companyService, IInsuranceService insuranceService, ApplicationDBContext context)
        {
            _companyInfoService = companyInfo;
            _companyService = companyService;
            _insuranceService = insuranceService;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompanyInfo()
        {
            var companyInfo = await _companyInfoService.GetAllWithData();
            if (companyInfo != null || !companyInfo.Any())
            {
                var result = companyInfo.Adapt<IEnumerable<UpdateCompanyInfoDto>>().ToList();


                return Ok(result);
            }
            var newCompanyInfo = new List<IEnumerable<CreateCompanyInfoDto>>();
            return NotFound(newCompanyInfo);

        }
        [HttpGet]
        public async Task<IActionResult> GetcompanyInfoById(int id)
        {
            var companyInfo = await _companyInfoService.FindById(id);

            if (companyInfo == null)
            {
                return NotFound("companyInfo Not Found");
            }
            return Ok(companyInfo);
        }
        [HttpPost]
        public async Task<IActionResult> AddCompanyInfo([FromBody] CreateCompanyInfoDto Company)
        {
            if (ModelState.IsValid)
            {
                var NewCompany = await _companyInfoService.AddCompanyInfo(Company);
                if (NewCompany == null) { return BadRequest("plz full all Felids"); }
                return Ok(NewCompany);
            }
            return BadRequest(" model not valid");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCompany([FromBody] UpdateCompanyInfoDto dto)
        {
            var CompanyInfo = await _companyInfoService.FindById(dto.CompanyInfoId);
            if (CompanyInfo == null)
            {
                return NotFound(" this CompanyInfo Not Found");
            }
            var UpdatedCompany = await _companyInfoService.UpdateCompanyInfo(dto);
            if (UpdatedCompany == null)
            {
                return BadRequest(" CompanyInfo  not updated");
            }
            else
            {
                return Ok(UpdatedCompany);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCompanyInfoById(int id)
        {

            var Company = await _companyInfoService.FindById(id);
            if (Company == null) { return NotFound("Company Not Found"); }
            await _companyInfoService.Delete(Company);
            await _companyInfoService.CommitChanges();
            return Ok(Company);
        }
        [HttpGet]
        public async Task<IActionResult> GetCompanyInsurance(int ComponayId, double Price)
        {
            var finddd = await _companyInfoService.GetLessInsurance(ComponayId,Price);
            return Ok(finddd);
        }
        [HttpGet]
        public async Task<IActionResult> GetCompanyInfobyCompanyId(int ComponayId)
        {
            if (ComponayId == null) return BadRequest("please enter Company Id");
            var CompanyInfo = await _companyInfoService.GetInfoByCompanyId(ComponayId);
            return Ok(CompanyInfo);
        } 
        [HttpGet]
        public async Task<IActionResult> GetCompanyOffers( int CompanyId,[Optional]  int carModelId ,double Price)
        {
          dynamic com;
           // var Company = await _companyService.FindByIdWithData(CompanyId);
            var Company = await _companyService.FindById(CompanyId);
            if(Company == null) { return BadRequest("No Company Found"); }
            ////if(Company.CompanyName==Companies.Royal)

            if (CompanyId == null) { return BadRequest ("Company Id Not Found"); }
            //var offers = await _companyInfoService.getOffers(carModelId);
            // var Company = await _companyService.FindById(CompanyId);
            if (Company.CompanyCode == CarCompanies.Royal.ToString())
            {
                if (Price < 750000) {
                    com = _context.CompanyInfo.Include(x => x.insurance.Where(x => x.Classificatin == Classificatin.LessThan750)).Where(x => x.CompanyId == CompanyId);
                    return Ok(com);
                }
               else 
                {
                    com = _context.CompanyInfo.Include(x => x.insurance.Where(x => x.Classificatin == Classificatin.MoreThan750)).Where(x => x.CompanyId == CompanyId);
                    return Ok(com);
                }
              
               

                

                // var benfites=await _companyBenfitsService.Find(x=>x.)


                
            }
            else
            {
                com = await _companyInfoService.FindAllWithData(x => x.CompanyId == CompanyId && x.CarModelId == carModelId);
                 
               

                return Ok(com);
                //}


                //  var companyInfo = await _companyInfoService.FindById(id);
            }
           // return Ok();
        }
        

        [HttpGet]
        public async Task<IActionResult> GetLessOffer( 
            [Optional] int carModelId, double Price)
        {
            
            var offers = await _companyInfoService.getlessOffers(carModelId,Price);

            return Ok(offers);
        }
        [HttpGet]
        public async Task<IActionResult> GetCompanyBenfitsByCompanyIdandType( string type,[Optional] int carModelId)
        {
            var companyInfo= await _companyInfoService.FindAllWithData(x=>x.CarModelId==carModelId);   
            var ins = await _insuranceService.FindAllWithData(x => x.insuranceType==type );
            return Ok(ins);
        }
    }
}

