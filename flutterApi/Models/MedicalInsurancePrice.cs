namespace flutterApi.Models
{
    public class MedicalInsurancePrice
    { public int Id { get; set; }
       public  float Premium { get; set; }
      public CompanyHealthInsuranceTypes CompanyHealthInsuranceTypes { get; set; }
        public int CompanyHealthInsuranceTypesId {  get; set; }
        public AgeLimits AgeLimits { get; set; }
        public int AgeLimitsId { get; set; }


    }
}
