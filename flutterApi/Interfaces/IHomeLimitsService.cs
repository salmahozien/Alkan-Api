using flutterApi.DTOs.Home.HomeLimitsDTOS;
using flutterApi.DTOs.Home.HomePriceDtos;
using flutterApi.Models;
using System.Runtime.InteropServices;

namespace flutterApi.Interfaces
{
    public interface IHomeLimitsService:IBaseRepository<HomeLimits>
    {
        Task<ReturnHomeLimits> AddHomeLimits(CreateHomeLimitsDto model);
        Task<ReturnPremiumAndTotalInstallment> GtPremiumAndTotalInstallment([Optional] double BuildingPrice, [Optional] double contentPrice, int CompanyId);
        Task<ReturnPriceDto> GetPrice(double Price, int CompanyId,string type);
    }
}
