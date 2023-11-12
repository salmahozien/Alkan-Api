using flutterApi.DTOs.Company;
using flutterApi.DTOs.CompanyInfo;

using flutterApi.Models;
using flutterApi.Services;
using System.Runtime.InteropServices;

namespace flutterApi.Interfaces
{
    public interface ICompanyInfoService : IBaseRepository<CompanyInfo>
    {
        Task<CompanyInfo> AddCompanyInfo(CreateCompanyInfoDto model);

        Task<CompanyInfo> DeleteCompanyInfo(UpdateCompanyInfoDto model);
        Task<CompanyInfo> UpdateCompanyInfo(UpdateCompanyInfoDto model);
        Task<float?> GetLessInsurance(int id,  double Price, [Optional] int carModelId);
        Task<CompanyInfo> GetInfoByCompanyId(int CompanyId);
        Task<List<CompanyOffer>> getlessOffers([Optional] int carModelId, double Price);


    }
}
