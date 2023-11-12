using flutterApi.DTOs.Company_Benfits_;
using flutterApi.Interfaces;
using flutterApi.Models;
using login.Models;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace flutterApi.Services
{
    public class CompanyBenfitsService : BaseRepository<CompanyBenfits>, ICompanyBenfitsService
    {
     
        public CompanyBenfitsService(ApplicationDBContext Context) : base(Context)
        {
            
        }

        public async Task<CompanyBenfits> AddCompanyBenfits(CreateCompanyBenfitsDto model)
        {

            if (model == null) { return null; }

            var CompanyBenfits = model.Adapt<CompanyBenfits>();
            if (CompanyBenfits == null)
            {
                return null;
            }
           


            await Add(CompanyBenfits);
            await CommitChanges();
           
            return CompanyBenfits;
        }

        public async Task<CompanyBenfits> DeleteCompanyBenfits(UpdateCompanyBenfitsDto model)
        {
            if (model == null) { return null; }
            var CompanyBenfits = await FindById(model.CompanyBenfitsId);
            if (CompanyBenfits == null)
            {
                return null;
            }
            await Delete(CompanyBenfits);
            await CommitChanges();
            return CompanyBenfits;
        }

        public async Task<CompanyBenfits> UpdateCompanyBenfits(UpdateCompanyBenfitsDto model)
        {
            if (model == null) { return null; }
            var CompanyBenfits = await FindById(model.CompanyBenfitsId);
            if (CompanyBenfits == null) { return null; }
            CompanyBenfits = model.Adapt<CompanyBenfits>();
            if (CompanyBenfits == null) { return null; }
           


            await Update(CompanyBenfits);
            await CommitChanges();
            return CompanyBenfits;
        }
        }
    }
