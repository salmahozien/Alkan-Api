namespace flutterApi.Models
{
    public class HomePrice
    {
        public int Id { get; set; }
        public double? PriceOfBuildings { get; set; }
        public double? PriceOfTheContentOfBuilding {  get; set; }
        public User User { get; set; }
        public string  UserId { get; set; }
        public HomeCompany HomeCompany { get; set; }
        public int HomeCompanyId { get; set; }

        
       
    }
}
