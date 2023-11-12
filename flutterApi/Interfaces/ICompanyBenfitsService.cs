using flutterApi.DTOs.Company_Benfits_;
using flutterApi.DTOs.Product;
using flutterApi.DTOs.ProductDto;
using flutterApi.Models;

namespace flutterApi.Interfaces
{
    public interface ICompanyBenfitsService:IBaseRepository<CompanyBenfits>

    {

        Task<CompanyBenfits> AddCompanyBenfits(CreateCompanyBenfitsDto model);
        Task<CompanyBenfits> UpdateCompanyBenfits(UpdateCompanyBenfitsDto model);
        Task<CompanyBenfits> DeleteCompanyBenfits(UpdateCompanyBenfitsDto model);
    }
}
