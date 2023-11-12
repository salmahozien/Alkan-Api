using flutterApi.Enums;

namespace flutterApi.DTOs.Company
{
    public class CompanyInsurance
    {
        public int CompanyId { get; set; }
        public int CarModedId { get; set; }
        public string CompanyName { get; set;}
        public  string InsuranceType { get; set; }
        public float InsurancePrice { get; set; }


    }
}
