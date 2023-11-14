namespace flutterApi.Models
{
    public class HomeLimits
    {
        public int HomeLimitsId { get; set; }
        public int From {  get; set; }
        public int To { get; set; }
        public int NetPremium { get; set; }
        public int TotalInstallment { get; set; }
        public HomeCompany HomeCompany { get; set; }
        public int HomeCompanyId { get; set; }

    }
}
