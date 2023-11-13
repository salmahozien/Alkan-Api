using flutterApi.DTOs.Medical.AgeLmit.MedicalInsurancePriceDto;
using flutterApi.Migrations;
using flutterApi.Models;

namespace flutterApi.Interfaces
{
    public interface ImedicalInsurancePricesService:IBaseRepository<MedicalInsurancePrice>
    {
        Task<ReturnMedicalInsurancePrice> AddMedicalInsurancePrice(CreateMedicalInsurancePriceDto model);
        Task<ReturnPriceAndPremium> GetMedicalInsurancePrice(int type, int age, int MedicalcOmpanyId, float Price);
    }
}
