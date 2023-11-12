using flutterApi.DTOs.Company_Benfits_;

namespace flutterApi.DTOs.Insurance
{
    public class CreateInsuranceDto
    {
        public string insuranceType { get; set; }
        public float insurancePrice { get; set; }
        public string? ConsumptionRatios { get; set; }
        // [Required]
        public string? Saviors { get; set; }
        // [Required]
        public string? PoliceReport { get; set; }
        public List<CreateCompanyBenfitsDto>? Benfits { get; set; }=new List<CreateCompanyBenfitsDto>();    
    }
}
