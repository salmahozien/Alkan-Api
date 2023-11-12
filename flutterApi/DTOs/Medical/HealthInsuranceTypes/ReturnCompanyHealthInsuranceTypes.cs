using flutterApi.Models;

namespace flutterApi.DTOs.Medical.HealthInsuranceTypes
{
    public class ReturnCompanyHealthInsuranceTypes
    {
        public string? message { get; set; } = string.Empty;
        public CompanyHealthInsuranceTypes? InsuranceTypes { get; set; }
    }
}
