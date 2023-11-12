using flutterApi.DTOs.Medical.PlacesOfTreatmentDetails;
using flutterApi.Models;
using flutterApi.Services;

namespace flutterApi.Interfaces
{
    public interface IPlaceOfTreatmentDetailsService : IBaseRepository<PlaceOfTreatmentDetails>
    {
        Task<ReturnPlaceOfTreatmentDetails> AddPlaceOfTreatmentDetails(CreatePlaceOfTreatmentDetailsDto model);
        Task<ReturnListPlaceOfTreatmentDetails> GetDetailsOfOnePlaceTreatment(int id);
        Task<ReturnNameAndStatusDto> GetDetailsOfOnePlaceTreatmentByType(int Placeid, int TypeId);
    }
}
