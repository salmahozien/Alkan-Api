namespace flutterApi.Models
{
    public class InsuranceRequest
    {
        public  int InsuranceRequestId{get;set;}
        
        public string CarModel { get; set; }
        public string BrandName { get; set; }
        public int carPrice { get; set; }
        public  string CompanyName { get; set; }
        public string CompanyInsuranceType { get; set; }
        public string Premium { get; set; }
        public bool? NeedPreviewer { get; set; }=false;
        public bool? Accepted { get; set; } = false;
        public User user { get; set; }
        public string UserId { get; set; }
    }
}
