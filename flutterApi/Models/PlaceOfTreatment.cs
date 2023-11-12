using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace flutterApi.Models
{
    public class PlaceOfTreatment
    {

        public int PlaceOfTreatmentId { get; set; }
        public string Name { get; set; }
        public MedicalCompany MedicalCompany { get; set; }
        public int MedicalCompanyId { get; set; }

        //  public CompanyHealthInsuranceTypes CompsnyHealthInsuranceTypes { get; set; }

        // public int CompanyHealthInsuranceTypesId { get; set; }

        //  public List<PlaceOfTreatmentDetails> PlaceOfTreatmentDetails { get; set; }=new List<PlaceOfTreatmentDetails>();
    }
}
