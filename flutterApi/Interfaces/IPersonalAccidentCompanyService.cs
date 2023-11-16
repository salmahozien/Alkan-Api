using flutterApi.DTOs.PersonalAccident.Company;
using flutterApi.Models;

namespace flutterApi.Interfaces
{
    public interface IPersonalAccidentCompanyService : IBaseRepository<PersonalAccidentCompany>
    {
        Task<ReturnPersonalAccidentCompany> AddCompany(CreatePersonalAccidentCompany model);
    }
}
