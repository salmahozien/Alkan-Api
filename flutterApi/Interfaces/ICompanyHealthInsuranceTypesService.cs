
using flutterApi.DTOs.Medical.HealthInsuranceTypes;
using flutterApi.Models;
using Twilio.Rest.Verify.V2.Service;

namespace flutterApi.Interfaces
{
    public interface ICompanyHealthInsuranceTypesService : IBaseRepository<CompanyHealthInsuranceTypes>
    {
        Task<ReturnCompanyHealthInsuranceTypes> addCompanyHealthInsuranceTypes(CreateCompanyHealthInsuranceTypes model);
        Task<ReturnListCompanyHealthInsuranceTypes> GetCompanyHealthInsuranceTypesByCompanyId(int id);
        Task<ReturnCompanyHealthTypesNameDto> GetTypesNameForOneComapny(int id);
    }
}
