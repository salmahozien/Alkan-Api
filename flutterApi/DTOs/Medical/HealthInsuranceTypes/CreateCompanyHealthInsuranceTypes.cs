using flutterApi.Models;

namespace flutterApi.DTOs.Medical.HealthInsuranceTypes
{
    public class CreateCompanyHealthInsuranceTypes
    {
        
        public string Name { get; set; }
        public double Amount { get; set; }
       // public MedicalCompany MedicalCompany { get; set; }
        public int MedicalCompanyId { get; set; }
    }
}
