namespace flutterApi.Models
{
    public class CompanyHealthInsuranceTypes
    {
        public int CompanyHealthInsuranceTypesId { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public MedicalCompany MedicalCompany { get; set; }
        public int MedicalCompanyId { get; set; }
        public List<typesMedicalDetails> typesMedicalDetails { get; set; }  =new List<typesMedicalDetails>();


       //  public List<PlaceOfTreatment> PlaceOfTreatment { get; set; }=new List<PlaceOfTreatment>();
    }
}
