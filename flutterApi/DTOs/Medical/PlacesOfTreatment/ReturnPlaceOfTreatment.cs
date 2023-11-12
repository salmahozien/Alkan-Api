using flutterApi.Models;

namespace flutterApi.DTOs.Medical.PlacesOfTreatment
{
    public class ReturnPlaceOfTreatment
    {
        public string? Message { get; set; } = string.Empty;
        public PlaceOfTreatment? PlaceOfTreatment { get; set; }
    }
}
