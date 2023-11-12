namespace flutterApi.Models
{
    public class AgeLimits
    {
        public int Id {  get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public MedicalCompany MedicalCompany { get; set; }
        public int MedicalCompanyId { get; set; }


    }
}
