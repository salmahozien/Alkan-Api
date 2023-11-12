using flutterApi.DTOs.Medical.AgeLmit;
using flutterApi.Models;

namespace flutterApi.Interfaces
{
    public interface IAgeLimitesService
    {
        Task<ReturnAgeLimits> AddAgeLimits( CreateAgeLimitesDto model);
    }
}
