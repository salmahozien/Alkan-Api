using flutterApi.Models;

namespace flutterApi.DTOs.Medical.PlacesOfTreatmentDetails
{
    public class ReturnPlaceOfTreatmentDetails
    {
        public string? message { get; set; } = string.Empty;
        public PlaceOfTreatmentDetails? placeOfTreatmentDetails { get; set; }
    }
}
