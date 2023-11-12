using flutterApi.DTOs.Company;
using flutterApi.Interfaces;
using flutterApi.Models;
using login.Models;
using Mapster;

namespace flutterApi.Services
{
    public class CompanyService : BaseRepository<Company>, ICompanyService
    {
        public CompanyService(ApplicationDBContext Context) : base(Context)
        {

        }

        public async Task<Company> AddCompany(CreateCompanyDto model)
        {
            if (model == null) { return null; }

            var Company = model.Adapt<Company>();
            if (Company == null)
            {
                return null;
            }

            await Add(Company);
            await CommitChanges();

            return Company;
        }

        public async Task<Company> DeleteCompany(UpdateCompanyDto model)
        {
            if (model == null) { return null; }
            var Company = await FindById(model.CompanyId);
            if (Company == null)
            {
                return null;
            }
            await Delete(Company);
            await CommitChanges();
            return Company;
        }
    }
}
