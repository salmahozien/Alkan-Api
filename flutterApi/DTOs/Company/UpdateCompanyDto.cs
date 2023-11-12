using Microsoft.Build.Framework;

namespace flutterApi.DTOs.Company
{
    public class UpdateCompanyDto
    {
        public int CompanyId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string CompanyCode { get; set; }
    }
}
