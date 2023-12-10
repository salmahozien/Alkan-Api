using flutterApi.Enums;

namespace flutterApi.Models
{
    public class MedicalCompany
    {
        public int MedicalCompanyId { get; set; }
        public MedicalComp CompanyName { get; set; }
        public List<CompanyHealthInsuranceTypes> Types { get; set; }=new List<CompanyHealthInsuranceTypes>();
        public List<PlaceOfTreatment> Treatments { get; set; } = new List<PlaceOfTreatment>();
        public List<MedicalPricingData> PricingData { get; set; }=new List<MedicalPricingData>();
    }
}
