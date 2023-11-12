


using flutterApi.DTOs.Policy;
using flutterApi.Models;

namespace flutterApi.Interfaces
{
    public interface IPolicyService:IBaseRepository<Policy>
    {
        Task<Policy> AddPolicy(CreatePolicyDto model);
        Task<Policy> UpdatePolicy(UpdatePolicyDto model);
        Task<Policy> DeletePolicy(UpdatePolicyDto model);
        Task<List<Policy>> GetAllUserPolice( string id);
    }
}
