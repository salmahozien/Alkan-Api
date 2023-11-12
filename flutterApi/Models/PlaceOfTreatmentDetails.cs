namespace flutterApi.Models
{
    public class PlaceOfTreatmentDetails
    {
        public int PlaceOfTreatmentDetailsId { get; set; }
        public string Name { get; set; }
       
        public PlaceOfTreatment PlaceOfTreatment { get; set; }
        public int PlaceOfTreatmentId { get; set; }
        public List<typesMedicalDetails> typesMedicalDetails { get; set; } = new List<typesMedicalDetails>();
    }
}
