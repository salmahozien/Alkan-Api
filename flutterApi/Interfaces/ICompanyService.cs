

using flutterApi.DTOs.Company;
using flutterApi.Models;

namespace flutterApi.Interfaces
{
    public interface ICompanyService:IBaseRepository<Company>
    {
        Task<Company> AddCompany(CreateCompanyDto model);
       
        Task<Company> DeleteCompany(UpdateCompanyDto model);
    }
}
