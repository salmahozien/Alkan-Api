using flutterApi.Models;

namespace flutterApi.DTOs.Medical.MedicalPricingDataDtos
{
    public class ReturnMedicalPricingData
    {
        public string? Message {  get; set; }   = string.Empty;
        public MedicalPricingData? MedicalPricingData { get; set; }
    }
}
