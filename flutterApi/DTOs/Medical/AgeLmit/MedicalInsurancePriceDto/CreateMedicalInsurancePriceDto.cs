using flutterApi.Models;

namespace flutterApi.DTOs.Medical.AgeLmit.MedicalInsurancePriceDto
{
    public class CreateMedicalInsurancePriceDto
    {
        public float Premium { get; set; }
       
        public int CompanyHealthInsuranceTypesId { get; set; }

        public int AgeLimitsId { get; set; }
    }
}
