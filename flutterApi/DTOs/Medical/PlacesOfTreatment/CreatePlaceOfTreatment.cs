using flutterApi.Models;

namespace flutterApi.DTOs.Medical.PlacesOfTreatment
{
    public class CreatePlaceOfTreatment
    {
        public string Name { get; set; }
        public int MedicalCompanyId { get; set; }



        public int CompanyHealthInsuranceTypesId { get; set; }
       
    }
}
