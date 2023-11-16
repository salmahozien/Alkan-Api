namespace flutterApi.Models
{
    public class PersonalAccidentPrice
    {
        public int Id { get; set; }
        public double? Price { get; set; }
        
        public User User { get; set; }
        public string UserId { get; set; }
        public PersonalAccidentCompany HomeCompany { get; set; }
        public int PersonalAccidentCompanyId { get; set; } 
    }
}
