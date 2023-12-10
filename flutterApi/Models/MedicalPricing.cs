using System.ComponentModel.DataAnnotations;

namespace flutterApi.Models
{
    public class MedicalPricingData
    {
        public int MedicalPricingDataId { get; set; }
        public string Type { get; set; }
        [DataType(DataType.Date)] 
        public DateTime DateOfBirth {  get; set; }   
       
        public User User { get; set; }
        public string UserId { get; set; }
        public CompanyHealthInsuranceTypes insuranceTypes { get; set; }
        public int CompanyHealthInsuranceTypesId { get; set; }

        public MedicalCompany MedicalCompany { get; set; }
        public int MedicalCompanyId { get; set; }




    }
}
