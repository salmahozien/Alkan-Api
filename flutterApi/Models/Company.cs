using Microsoft.Build.Framework;

namespace flutterApi.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string CompanyCode { get; set;}

        
        public  virtual ICollection<CompanyInfo> CompanyInfos { get; set; } 
        
    }
    }

