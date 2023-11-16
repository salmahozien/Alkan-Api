namespace flutterApi.Models
{
    public class PersonalAccidentLimit
    {
        public int Id { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public int? NetPremium { get; set; }
        public int TotalInstallment { get; set; }
        public PersonalAccidentCompany MedicalCompany { get; set; }
        public int PersonalAccidentCompanyId { get; set; }
    }
}
