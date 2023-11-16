using flutterApi.DTOs.Home.HomeLimitsDTOS;
using flutterApi.DTOs.PersonalAccident.Limits;
using flutterApi.Models;

namespace flutterApi.Interfaces
{
    public interface IPersonalAccidentLimitService:IBaseRepository<PersonalAccidentLimit>
    {
        Task<ReturnPersonalAccidentLimit> AddPersonalAccidentLimit(CreatePersonalAccidentLimit model);
        Task<ReturnPriceDto> GetLimit(double Price, int CompanyId);
    }
}
