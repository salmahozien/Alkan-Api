using flutterApi.Models;

namespace flutterApi.DTOs.Medical.HealthInsuranceTypes
{
    public class ReturnCompanyHealthTypesNameDto
    {
        public string? Message { get; set; } = string.Empty;
        public List<CompanyHealthInsuranceTypes> Names { get; set; }=new List<CompanyHealthInsuranceTypes>(); 
    }
}
