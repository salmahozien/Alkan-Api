using flutterApi.DTOs.PersonalAccident.Price;
using flutterApi.Models;

namespace flutterApi.Interfaces
{
    public interface IPersonalAccidentPriceService:IBaseRepository<PersonalAccidentPrice>
    {
        Task<ReturnPersonalAccidentPrice> AddPersonalAccidentPrice(CreatePersonalAccidentPrice model);
        Task<ReturnPermiumAndTotalForPersonal> GetPremiumAndTotalInstallment(int PersonalAccidentPriceId);
    }
}
