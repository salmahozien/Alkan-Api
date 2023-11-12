using flutterApi.DTOs.Medical.PlacesOfTreatment;
using flutterApi.Models;

namespace flutterApi.Interfaces
{
    public interface IPlaceOfTreatmentService : IBaseRepository<PlaceOfTreatment>
    {
        Task<ReturnPlaceOfTreatment> AddPlaceOfTreatment(CreatePlaceOfTreatment model);
        Task<ReturnListPlaceOfTreatment> GetAllPlaceOfTreatmentByCompanyId(int companyId);
    }
}
