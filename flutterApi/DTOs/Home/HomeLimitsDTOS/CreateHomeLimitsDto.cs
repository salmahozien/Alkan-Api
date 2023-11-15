using flutterApi.Models;

namespace flutterApi.DTOs.Home.HomeLimitsDTOS
{
    public class CreateHomeLimitsDto
    {
        public int From { get; set; }
        public int To { get; set; }
       public int? NetPremium {  get; set; }
        public int TotalInstallment {  get; set; }   
        public int HomeCompanyId { get; set; }
    }
}
