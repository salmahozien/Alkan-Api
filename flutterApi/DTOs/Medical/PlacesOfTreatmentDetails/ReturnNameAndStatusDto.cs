namespace flutterApi.DTOs.Medical.PlacesOfTreatmentDetails
{
    public class ReturnNameAndStatusDto
    {
        public string? Message { get; set; }=string.Empty;
        public List<ReturnNameAndStatus>? NameAndStatus { get; set; }=new List<ReturnNameAndStatus>();
       

    }
}
