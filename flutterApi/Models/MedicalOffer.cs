using System.ComponentModel.DataAnnotations;

namespace flutterApi.Models
{
    public class MedicalOffer
    {
        
        public DateTime DateOfBirth {  get; set; }
        public double Price {  get; set; }  
        public CompanyHealthInsuranceTypes CompanyHealthInsurance { get; set; }
        public int CompanyHealthInsuranceTypesId { get; set; }


    }
}
