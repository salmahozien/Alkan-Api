using flutterApi.DTOs.Medical.MedicalCompanies;
using flutterApi.Interfaces;
using flutterApi.Models;
using login.Models;
using Mapster;

namespace flutterApi.Services
{
    public class MedicalCompanyService : BaseRepository<MedicalCompany>, IMedicalCompanyService
    {
        public MedicalCompanyService(ApplicationDBContext Context) : base(Context)
        {
        }

        public async Task<ReturnMedicalCompanyDto> AddMedicalCompany(CreateMedicalCompanyDto model)
        {
            var output = new ReturnMedicalCompanyDto();
            if (model == null) { output.message = "Empty Model"; }
            else
            {
                var MedicalCompany = model.Adapt<MedicalCompany>();
                if (MedicalCompany == null) { output.message = "Can't Add Medical Company"; }
                else
                {
                    await Add(MedicalCompany);
                    await CommitChanges();
                    output.MedicalCompany = MedicalCompany;
                }
            }
            return output;
        }

        public async Task<ReturnMedicalCompanyDto> FindMedicalCompanyById(int Id)
        {
            var output = new ReturnMedicalCompanyDto();
            var MedicalCompany = await FindById(Id);
            if (MedicalCompany == null) { output.message = "Medigcal Company not Found!"; }
            else
            {
                output.MedicalCompany = MedicalCompany;
            }
            return output;
        }

    }
}
