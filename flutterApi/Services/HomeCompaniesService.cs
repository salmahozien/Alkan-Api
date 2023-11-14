using flutterApi.DTOs.Home.HomeCompaniesDto;
using flutterApi.Interfaces;
using flutterApi.Models;
using login.Models;
using Mapster;

namespace flutterApi.Services
{
    public class HomeCompaniesService : BaseRepository<HomeCompany>, IHomeCompaniesService
    {
        public HomeCompaniesService(ApplicationDBContext Context) : base(Context)
        {
        }

        public async Task<ReturnHomeCompaniesDtO> AddHomeCompany(CreateHomeCompanyDto model)
        {
           var output=new ReturnHomeCompaniesDtO();
            if (model == null) { output.Message = "Empty Model!"; }
            else
            {
               var HomeCompany= model.Adapt<HomeCompany>();
                if(HomeCompany==null) { output.Message = "Can't Add Company!"; }
                else
                {
                    await Add(HomeCompany);
                    await CommitChanges();
                    output.homeCompany = HomeCompany;
                }
                
            }
            return output;  
        }

       
    }
}
