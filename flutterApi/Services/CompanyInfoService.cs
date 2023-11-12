using flutterApi.DTOs.Company;
using flutterApi.DTOs.CompanyInfo;
using flutterApi.Enums;
using flutterApi.Interfaces;
using flutterApi.Models;
using login.Models;
using Mapster;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace flutterApi.Services
{
    public class CompanyInfoService : BaseRepository<CompanyInfo>, ICompanyInfoService
    {

        private readonly ICompanyBenfitsService _companyBenfitsService;
        private readonly ICompanyService _companyService;
        private readonly ICarModelService _carModelService;
        private readonly ApplicationDBContext _context;
        public CompanyInfoService(ApplicationDBContext Context, ICompanyBenfitsService companyBenfitsService, ICompanyService companyService, ICarModelService carModelService, ApplicationDBContext context) : base(Context)
        {
            _companyBenfitsService = companyBenfitsService;
            _companyService = companyService;
            _carModelService = carModelService;
            _context = context;
        }

        public async Task<CompanyInfo> AddCompanyInfo(CreateCompanyInfoDto model)
        {




            if (model == null) { return null; }

           
            var CompanyInfo = model.Adapt<CompanyInfo>();
            if (CompanyInfo == null)
            {
                return null;
            }

            var company = await _companyService.FindById(model.CompanyId);
            if (company == null) { return null; }
            _companyService.Adapt(company);
          

            await Add(CompanyInfo);
            await CommitChanges();
          
           return CompanyInfo;


        }

        public async Task<CompanyInfo> DeleteCompanyInfo(UpdateCompanyInfoDto model)
        {
            if (model == null) { return null; }
            var Company = await FindById(model.CompanyInfoId);
            if (Company == null)
            {
                return null;
            }
            await Delete(Company);
            await CommitChanges();
            return Company;
        }

        public async Task<CompanyInfo> UpdateCompanyInfo(UpdateCompanyInfoDto model)
        {
            if (model == null) { return null; }
            var CompanyInfo = await FindByIdWithData(model.CompanyInfoId);
            if (CompanyInfo == null) { return null; }
            CompanyInfo = model.Adapt<CompanyInfo>();
            if (CompanyInfo == null) { return null; }
           

            await Update(CompanyInfo);
            await CommitChanges();
            return CompanyInfo;
        }
        public async Task<float?> GetLessInsurance(int CompanyId,double Price, [Optional] int carModelId)
        {
            float less = 0;
          
            if (CompanyId == null) { return null; }
            
              
                    var Company = await _companyService.FindById(CompanyId);
                if(Company == null) { return null; }



            if (Company.CompanyCode == CarCompanies.Royal.ToString())
            {
                if (Price < 750000)
                {
                    // var insurance = await FindAllWithData(x => x.CompanyId == CompanyId);
                    var insurance = _context.CompanyInfo.Include(x => x.insurance.Where(x => x.Classificatin == Classificatin.LessThan750)).Where(x => x.CompanyId == CompanyId);
                    foreach (var r in insurance)
                    {


                        less = r.insurance.Min(x => r.insurance.Min(x => x.insurancePrice));
                    }
                    return less;
                }
                if (Price > 750000)
                {
                    var insurance = _context.CompanyInfo.Include(x => x.insurance.Where(x => x.Classificatin == Classificatin.MoreThan750)).Where(x => x.CompanyId == CompanyId);

                    foreach (var r in insurance)
                    {


                        less = r.insurance.Min(x => r.insurance.Min(x => x.insurancePrice));
                    }
                    return less;
                }
            }



            else
            {
                var company = await _companyService.FindById(CompanyId);
                if (company == null) { return null; }
                var companyInfo = await FindAllWithData(c => c.CompanyId == CompanyId && c.CarModelId == carModelId);
                 less = companyInfo.Min(x => x.insurance.Min(x => x.insurancePrice));
                if (companyInfo != null)
                {

                    return less;
                }
            }

            
            return null;



        }





        public async Task<Insurance> GetInsurance(int CompanyId, [Optional] int carModelId)
        {
            if (CompanyId != null)
            {
                
                if (CompanyId == 1)
                {
                    var Company = await _companyService.FindById(CompanyId);

                    if (Company != null)
                    {
                        var insurance = await FindAllWithData(x => x.CompanyId == CompanyId);
                        var ins = insurance.ToList();


                       
                        return (Insurance)insurance;
                      

                    }


                }
                else
                {
                    var company = await _companyService.FindById(CompanyId);
                    if (company == null) { return null; }
                    var companyInfo = await FindAllWithData(c => c.CompanyId == CompanyId );
                    var com = companyInfo.ToList();
                
                    return null;

                }

            }
            return null;



        }







        public async Task<CompanyInfo> GetInfoByCompanyId(int CompanyId)
        {
            var x = ' ';
            if (CompanyId == null) { return null; }
            var Company = await _companyService.FindByIdWithData(CompanyId);
            if (Company != null)
            {
                // var info = await GetAllWithData();
                var info = await FindAllWithData(x => x.CompanyId == CompanyId);

                var result = info.Where(x => x.CompanyId == CompanyId).ToList();
                foreach (var item in result)
                {

                    //  x= item.Adapt<CompanyInfo>().ToString();

                }

            }
            return null;

        }
        public async Task<List<CompanyOffer>> getlessOffers([Optional] int carModelId, double Price)
        {
            var allcompany = await _companyService.GetAll();
            var lst = new List<CompanyOffer>();

            foreach (var item in allcompany)
            {

               
                var offer = await GetLessInsurance(item.CompanyId, Price, carModelId);
              
                var companyoffer = new CompanyOffer
                {
                    companyId = item.CompanyId,
                    companyName = item.CompanyName,
                    offer = offer.Value



                };
                lst.Add(companyoffer);

            }
            return lst;
        }
       
     

        
            }


        }
  