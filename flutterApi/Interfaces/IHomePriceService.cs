using flutterApi.DTOs.Home.HomePriceDtos;
using flutterApi.Models;

namespace flutterApi.Interfaces
{
    public interface IHomePriceService:IBaseRepository<HomePrice>
    {
        Task<ReturnHomePriceDto> AddHomePrice(CreateHomePriceDto homePriceDto);
         Task<ReturnPremiumAndTotalInstallment> GetPremiumAndTotalInstallment(int HomePriceId);
    }
}
