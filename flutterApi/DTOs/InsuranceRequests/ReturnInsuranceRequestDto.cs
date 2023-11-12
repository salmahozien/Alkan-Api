namespace flutterApi.DTOs.InsuranceRequests
{
    public class ReturnInsuranceRequestDto
    {
        public string ?Message { get; set; }=string.Empty;
        public InsuranceRequestDto ? InsuranceRequest { get; set; }
    }
}
