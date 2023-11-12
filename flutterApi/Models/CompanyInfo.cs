using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace flutterApi.Models
{
    public class CompanyInfo
    {
        public int CompanyInfoId { get; set; }
        [Required]
        public virtual Company Company { get; set; }
        [Required]

        public int CompanyId { get; set; }
        public virtual CarModel? CarModel { get; set; }
        public int? CarModelId { get; set; }

        [Required]

     
        public virtual List<Insurance> insurance { get; set; }=new List<Insurance>();
        
    }
}

       