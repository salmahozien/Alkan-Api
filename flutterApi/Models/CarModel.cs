using Microsoft.Build.Framework;

namespace flutterApi.Models
{
    public class CarModel
    {
        public int CarModelId { get; set; }
        [Required]
        public string ModelName { get; set; }
        public List<CompanyInfo> ?CompanyInfo { get; set; }  
      
    }
}
