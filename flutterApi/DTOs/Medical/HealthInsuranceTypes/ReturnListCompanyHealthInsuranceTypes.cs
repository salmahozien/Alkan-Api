using flutterApi.Models;

namespace flutterApi.DTOs.Medical.HealthInsuranceTypes
{
    public class ReturnListCompanyHealthInsuranceTypes
    {
        public string? message { get; set; } = string.Empty;
        public List<CompanyHealthInsuranceTypes>? InsuranceTypes { get; set; } = new List<CompanyHealthInsuranceTypes>();
    }
}
