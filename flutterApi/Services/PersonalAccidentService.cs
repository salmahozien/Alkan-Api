using flutterApi.DTOs.PersonalAccident.Company;
using flutterApi.Interfaces;
using flutterApi.Models;
using login.Models;
using Mapster;

namespace flutterApi.Services
{
    public class PersonalAccidentCompanyService : BaseRepository<PersonalAccidentCompany>, IPersonalAccidentCompanyService
    {
        public PersonalAccidentCompanyService(ApplicationDBContext Context) : base(Context)
        {
        }

        public async Task<ReturnPersonalAccidentCompany>AddCompany(CreatePersonalAccidentCompany model)
        {
           var output =new ReturnPersonalAccidentCompany();
            if (model == null) { output.Message = "Empty Model!"; }
            else
            {
                var company= model.Adapt<PersonalAccidentCompany>();
                if(company==null) { output.Message = "Can't Add Company!"; }
                else
                {
                    await Add(company);
                    await CommitChanges();
                    output.PersonalAccidentCompany = company;
                }
            }
            return output;
        }
    }
}
