using flutterApi.Models;

namespace flutterApi.DTOs.Medical.PlacesOfTreatmentDetails
{
    public class ReturnListPlaceOfTreatmentDetails
    {
        public string? message { get; set; } = string.Empty;
        public List< PlaceOfTreatmentDetails>? placeOfTreatmentDetails { get; set; } =new List< PlaceOfTreatmentDetails>();
    }
}
