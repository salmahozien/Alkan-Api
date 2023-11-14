using flutterApi.Models;

namespace flutterApi.DTOs.Home.HomeCompaniesDto
{
    public class ReturnHomeCompaniesDtO
    {
        public string? Message { get; set; } = string.Empty;
        public HomeCompany? homeCompany { get; set; }
    }
}
