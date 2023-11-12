using flutterApi.DTOs.Medical.HealthInsuranceTypes;
using flutterApi.DTOs.Medical.MedicalCompanies;
using flutterApi.Models;

namespace flutterApi.Interfaces
{
    public interface IMedicalCompanyService : IBaseRepository<MedicalCompany>
    {
        Task<ReturnMedicalCompanyDto> AddMedicalCompany(CreateMedicalCompanyDto model);
        Task<ReturnMedicalCompanyDto> FindMedicalCompanyById(int Id);
        
    }
}
