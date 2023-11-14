using flutterApi.DTOs.Home.HomeCompaniesDto;
using flutterApi.Models;

namespace flutterApi.Interfaces
{
    public interface IHomeCompaniesService:IBaseRepository<HomeCompany>
    {
        Task<ReturnHomeCompaniesDtO> AddHomeCompany(CreateHomeCompanyDto model);
    }
}
