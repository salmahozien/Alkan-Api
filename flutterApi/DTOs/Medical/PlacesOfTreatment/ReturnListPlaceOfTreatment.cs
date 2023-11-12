using flutterApi.Models;

namespace flutterApi.DTOs.Medical.PlacesOfTreatment
{
    public class ReturnListPlaceOfTreatment
    {
        public string? Message { get; set; } = string.Empty;
        public List< PlaceOfTreatment>? PlaceOfTreatment { get; set; }=new List< PlaceOfTreatment>();
    }
}
