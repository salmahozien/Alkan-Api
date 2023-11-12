using flutterApi.DTOs.Company_Benfits_;
using flutterApi.Enums;

namespace flutterApi.Models
{
    public class Insurance
    {
        public int Id { get; set; }
        public string insuranceType { get; set; }
        public float insurancePrice { get; set; }
        public string? ConsumptionRatios { get; set; }
        // [Required]
        public string? Saviors { get; set; }
        public CompanyInfo CompanyInfo { get; set; }
        public int CompanyInfoId { get; set; }
        // [Required]
        public string? PoliceReport { get; set; }
        public Classificatin? Classificatin { get; set; }
        public List<CompanyBenfits>? Benfits { get; set; } 

    }
}
