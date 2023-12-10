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
        private readonly IMedicalPricingDataService _medicalPricingDataService;



        public medicalInsurancePricesService(ApplicationDBContext Context, IMedicalCompanyService medicalCompanyService, ICompanyHealthInsuranceTypesService healthInsuranceTypes, IAgeLimitesService ageLimitesService, IMedicalPricingDataService medicalPricingDataService) : base(Context)
        {
            _medicalCompanyService = medicalCompanyService;
            _healthInsuranceTypes = healthInsuranceTypes;
            _ageLimitesService = ageLimitesService;
            _medicalPricingDataService = medicalPricingDataService;
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

        public async Task<ReturnPriceAndPremium> GetMedicalInsurancePrice(int MedicalInsurancePricingDataId)
        {
          var output=new ReturnPriceAndPremium();
            var MedicalInsuranceData = await _medicalPricingDataService.FindById(MedicalInsurancePricingDataId);
            if(MedicalInsuranceData==null) { output.Message = "Can't Find Medical Pricing Data"; }
            else {
                var age =DateTime.Now.Year -  MedicalInsuranceData.DateOfBirth.Year;
                var CompanyType = await _healthInsuranceTypes.Find(x => x.MedicalCompanyId == MedicalInsuranceData.MedicalCompanyId && x.CompanyHealthInsuranceTypesId == MedicalInsuranceData.CompanyHealthInsuranceTypesId);
                if(CompanyType==null) { output.Message = "Company Doesn't Contain This Type!"; }
                else
                {
                   var ageLimitId= await _ageLimitesService.GetAgeLimitId(age, MedicalInsuranceData.MedicalCompanyId);
                   if(ageLimitId.Message!=string.Empty) { output.Message = ageLimitId.Message; }
                    else
                    {
                        var InsurancePrice= await Find(x=>x.AgeLimitsId==ageLimitId.Id && x.CompanyHealthInsuranceTypesId== MedicalInsuranceData.CompanyHealthInsuranceTypesId);
                        if(InsurancePrice==null) { output.Message = "Don't Have Premium"; }
                        else
                        {
                            var  x= new PriceAndPremium()
                            {
                                Premium= InsurancePrice.Premium,
                                Price = InsurancePrice.Premium

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
