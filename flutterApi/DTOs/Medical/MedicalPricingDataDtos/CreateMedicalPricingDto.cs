using flutterApi.Models;

namespace flutterApi.DTOs.Medical.MedicalPricingDataDtos
{
    public class CreateMedicalPricingDataDto
    {
        public string Type { get; set; }
        public DateTime DatOfBirth { get; set; }
       
    
        public string UserId { get; set; }
        public int MedicalCompanyId { get; set; }
        public int CompanyHealthInsuranceTypesId { get; set; }


    }
}
