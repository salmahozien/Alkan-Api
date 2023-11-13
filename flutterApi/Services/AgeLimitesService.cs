using flutterApi.DTOs.Medical.AgeLmit;
using flutterApi.Interfaces;
using flutterApi.Models;
using login.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace flutterApi.Services
{
    public class AgeLimitesService : BaseRepository<AgeLimits>, IAgeLimitesService
    {
        public AgeLimitesService(ApplicationDBContext Context) : base(Context)
        {
        }

       

        public async Task<ReturnAgeLimits> AddAgeLimits(CreateAgeLimitesDto model)
        {
            var output = new ReturnAgeLimits();
            if (model == null) { output.Message = "Empty Model"; }
            else
            {
                var AgeLimits = model.Adapt<AgeLimits>();
                if(AgeLimits==null) { output.Message = "Can't Add Age Limit"; }
                else
                {
                    await Add(AgeLimits);
                    await CommitChanges();
                    output.AgeLimit = AgeLimits;
                }
            }
            return output;
        }

        public async Task<ReturnSearchAgeLimt>GetAgeLimitId(int age,int MedicalCompanyId)
        {
          var output= new ReturnSearchAgeLimt();

            
            var ageLimits=await FindAll(x=>x.MedicalCompanyId==MedicalCompanyId);
            foreach (var item in ageLimits)
            {
                if (item.From == age)
                {
                    output.Id = item.Id;
                    output.Message = string.Empty;
                    break;
                }
               
                if (item.To == age)
                {
                    output.Id = item.Id;
                    output.Message = string.Empty;
                    break;

                }
                if(item.From <age && item.To > age)
                {
                    output.Id = item.Id;
                    output.Message = string.Empty;
                    break;
                }

                else
                {
                    output.Message = "Wrong Age";
                }
            }
            return output;

        }
    }
}
