using Microsoft.Build.Framework;

namespace flutterApi.DTOs.Company
{
    public class CreateCompanyDto
    {
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string CompanyCode { get; set; }
    }
}
