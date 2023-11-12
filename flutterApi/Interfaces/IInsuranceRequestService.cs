using flutterApi.DTOs.InsuranceRequests;
using flutterApi.Models;

namespace flutterApi.Interfaces
{
    public interface IInsuranceRequestService:IBaseRepository<InsuranceRequest>
    {
        Task<ReturnInsuranceRequestDto> AddInsuranceRequest(InsuranceRequestDto model);
        Task<ReturnInsuranceRequestDto> GetInsuranceRequestById(int id);
        Task<ReturnInsuranceRequestDto> EditInsuranceRequest(UpdateInsuranceRequestDto dto);

    }
}
