using flutterApi.Models;

namespace flutterApi.DTOs.Medical.PlacesOfTreatmentDetails
{
    public class CreatePlaceOfTreatmentDetailsDto
    {
        public string Name { get; set; }
        public string Status { get; set; }
      
        public int PlaceOfTreatmentId { get; set; }
    }
}
