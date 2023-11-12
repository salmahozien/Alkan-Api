using flutterApi.DTOs.Medical.HealthInsuranceTypes;
using flutterApi.Interfaces;
using flutterApi.Models;
using login.Models;
using Mapster;

namespace flutterApi.Services
{
    public class CompanyHealthInsuranceTypesService : BaseRepository<CompanyHealthInsuranceTypes>, ICompanyHealthInsuranceTypesService
    {
        private readonly IMedicalCompanyService _medicalCompanyService;
        public CompanyHealthInsuranceTypesService(ApplicationDBContext Context, IMedicalCompanyService medicalCompanyService) : base(Context)
        {
            _medicalCompanyService = medicalCompanyService;
        }

        public async Task<ReturnCompanyHealthInsuranceTypes> addCompanyHealthInsuranceTypes(CreateCompanyHealthInsuranceTypes model)
        {
            var output = new ReturnCompanyHealthInsuranceTypes();
            if (model == null) { output.message = "Empty Model"; }
            else
            {
                var HealthType = model.Adapt<CompanyHealthInsuranceTypes>();
                if (HealthType == null)
                {
                    output.message = "Can't Add Type";
                }
                else
                {
                    await Add(HealthType);
                    await CommitChanges();
                    output.InsuranceTypes = HealthType;
                }
            }
            return output;

        }

        public async Task<ReturnListCompanyHealthInsuranceTypes> GetCompanyHealthInsuranceTypesByCompanyId(int id)
        {
            var outPut = new ReturnListCompanyHealthInsuranceTypes();
            var MedicalCompany= await _medicalCompanyService.FindById(id);
            if(MedicalCompany == null) { outPut.message = " Company Not Found!"; }
            else
            {
                var  InsuranceType= await FindAll(x=>x.MedicalCompanyId==id);
                if(InsuranceType.Count()==0) { outPut.message = "This Company Don't Have Medical Insurance Types"; }
                else
                {
                    foreach(var item in InsuranceType)
                    {
                        outPut.InsuranceTypes.Add(item);
                    }
                }
            }
            return outPut;  
        }
        public async Task<ReturnCompanyHealthTypesNameDto> GetTypesNameForOneComapny(int id)
        {
            var output= new ReturnCompanyHealthTypesNameDto();
            var MedicalCompany = await _medicalCompanyService.FindById(id);
            if (MedicalCompany == null) { output.Message = " Company Not Found!"; }
            else
            {
                var InsuranceType = await FindAll(x => x.MedicalCompanyId == id);
                if (InsuranceType.Count() == 0) { output.Message = "This Company Don't Have Medical Insurance Types"; }
                else
                {
                    foreach (var item in InsuranceType)
                    {
                        var x = item.Adapt<CompanyHealthInsuranceTypes>();
                        output.Names.Add(x);
                    }
                }
            }
            return output;

        }
    }
}
