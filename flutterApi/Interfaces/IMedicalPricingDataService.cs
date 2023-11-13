using flutterApi.DTOs.Medical.MedicalPricingDataDtos;
using flutterApi.Models;

namespace flutterApi.Interfaces
{
    public interface IMedicalPricingDataService:IBaseRepository<MedicalPricingData>
    {
        Task<ReturnMedicalPricingData> AddMedicalPricingData(CreateMedicalPricingDataDto model);
    }
}
