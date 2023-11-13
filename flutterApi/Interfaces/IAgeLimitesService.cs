using flutterApi.DTOs.Medical.AgeLmit;
using flutterApi.Models;

namespace flutterApi.Interfaces
{
    public interface IAgeLimitesService:IBaseRepository<AgeLimits>
    {
        Task<ReturnAgeLimits> AddAgeLimits( CreateAgeLimitesDto model);
        Task<ReturnSearchAgeLimt> GetAgeLimitId(int age,int  MedicalCompanyId);
    }
}
