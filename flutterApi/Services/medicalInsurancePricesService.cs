using flutterApi.DTOs.Medical.AgeLmit.MedicalInsurancePriceDto;
using flutterApi.Interfaces;
using flutterApi.Models;
using login.Models;
using Mapster;
using System.ComponentModel.DataAnnotations;

namespace flutterApi.Services
{
    public class medicalInsurancePricesService : BaseRepository<MedicalInsurancePrice>, ImedicalInsurancePricesService
    {
        private readonly IMedicalCompanyService _medicalCompanyService;
        private readonly ICompanyHealthInsuranceTypesService _healthInsuranceTypes;
        private readonly IAgeLimitesService _ageLimitesService;



        public medicalInsurancePricesService(ApplicationDBContext Context, IMedicalCompanyService medicalCompanyService, ICompanyHealthInsuranceTypesService healthInsuranceTypes, IAgeLimitesService ageLimitesService) : base(Context)
        {
            _medicalCompanyService = medicalCompanyService;
            _healthInsuranceTypes = healthInsuranceTypes;
            _ageLimitesService = ageLimitesService;
        }

        public async Task<ReturnMedicalInsurancePrice> AddMedicalInsurancePrice(CreateMedicalInsurancePriceDto model)
        {
           var output= new ReturnMedicalInsurancePrice();
            if(model ==null) { output.Message = "Empty Model"; }
            else
            {
                var MedicalPrice= model.Adapt<MedicalInsurancePrice>();
                if(MedicalPrice==null) { output.Message = "Can't Add Model"; }
                else
                {
                    await Add(MedicalPrice);
                    await CommitChanges();
                    output.MedicalInsurancePrice= MedicalPrice;
                }
            }
            return output;
        }

        public async Task<ReturnPriceAndPremium> GetMedicalInsurancePrice(int type, int age, int MedicalCompanyId,float Price)
        {
          var output=new ReturnPriceAndPremium();
            var medicalCompany = await _medicalCompanyService.FindById(MedicalCompanyId);
            if(medicalCompany==null) { output.Message = "Company Not Found!"; }
            else
            {
                var CompanyType = await _healthInsuranceTypes.Find(x => x.MedicalCompanyId == medicalCompany.MedicalCompanyId && x.CompanyHealthInsuranceTypesId == type);
                if(CompanyType==null) { output.Message = "Company Doesn't Contain This Type!"; }
                else
                {
                   var ageLimitId= await _ageLimitesService.GetAgeLimitId(age, MedicalCompanyId);
                   if(ageLimitId.Message!=string.Empty) { output.Message = ageLimitId.Message; }
                    else
                    {
                        var InsurancePrice= await Find(x=>x.AgeLimitsId==ageLimitId.Id && x.CompanyHealthInsuranceTypesId==type);
                        if(InsurancePrice==null) { output.Message = "Don't Have Premium"; }
                        else
                        {
                            var  x= new PriceAndPremium()
                            {
                                Premium= InsurancePrice.Premium,
                                Price = Price * InsurancePrice.Premium

                        };
                            output.PriceAndPremium = x;
                        }
                    }
                }
            }
         return output;
        }
    }
}
