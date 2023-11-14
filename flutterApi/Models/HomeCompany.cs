using flutterApi.Enums;

namespace flutterApi.Models
{
    public class HomeCompany
    {
        public int HomeCompanyId { get; set; }
       public HomeCompanies CompanyName { get; set; } 
        public List<HomePrice> PriceList { get; set; } = new List<HomePrice>();

    }
}
