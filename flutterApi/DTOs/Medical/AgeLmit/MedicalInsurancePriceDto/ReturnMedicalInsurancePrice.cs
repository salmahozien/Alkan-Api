using flutterApi.Models;

namespace flutterApi.DTOs.Medical.AgeLmit.MedicalInsurancePriceDto
{
    public class ReturnMedicalInsurancePrice
    {
        public string? Message { get; set; }=string.Empty;
        public MedicalInsurancePrice? MedicalInsurancePrice { get; set; }
    }
}
