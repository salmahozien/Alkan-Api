using flutterApi.DTOs.Company_Benfits_;
using flutterApi.DTOs.Insurance;

using flutterApi.Models;

using Microsoft.Build.Framework;

namespace flutterApi.DTOs.CompanyInfo
{
    public class CreateCompanyInfoDto
    {

        [Required]

        public virtual int CompanyId { get; set; }
        // [Required]
        public int? CarModelId { get; set; }
        public List<CreateInsuranceDto> insurance { get; set; }
        


        //public int CompanyInfoId { get; set; }
        //[Required]
        //public virtual Company Company { get; set; }
        //[Required]

        //public int CompanyId { get; set; }
        //public virtual CarModel? CarModel { get; set; }
        //public int? CarModelId { get; set; }

        //[Required]

        //public string Type { get; set; }
        ////public List<InsuranceTypes> InsuranceTypes { get; set; }
        //public List<Insurance> insurance { get; set; }
        //[Required]
        //public float InsurancePrice { get; set; }

        //[Required]
        ////public virtual Company Company { get; set; }
        //[Required]

        //public virtual int CompanyId { get; set; }
        //[Required]

        //public string Type { get; set; }
        //[Required]
        //public float InsurancePrice { get; set; }


        //public List<CompanyBenfits> Benfits { get; set; }
    }
}


        // public string Type { get; set; }
        // [Required]
        // public float InsurancePrice { get; set; }
       // [Required]

        


       
        //public List<CreateCompanyBenfitsDto>? Benfits { get; set; }

       // public List<int>? Benfits { get; set; }
    
