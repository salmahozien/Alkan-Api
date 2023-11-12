using flutterApi.Models;

namespace flutterApi.DTOs.Medical.MedicalCompanies
{
    public class ReturnMedicalCompanyDto
    {
        public string? message { get; set; } = string.Empty;
        public MedicalCompany? MedicalCompany { get; set; }
    }
}
