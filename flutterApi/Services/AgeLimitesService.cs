using flutterApi.DTOs.Medical.AgeLmit;
using flutterApi.Interfaces;
using flutterApi.Models;
using login.Models;
using Mapster;

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
    }
}
