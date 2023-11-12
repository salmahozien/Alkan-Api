using System.ComponentModel.DataAnnotations;

namespace flutterApi.Models
{
    public class CompanyBenfits
    {
        public int CompanyBenfitsId{get; set;}
        [Required]
        public string benfit { get; set; }
  
    }
}
