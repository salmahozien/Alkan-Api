using flutterApi.DTOs.Company_Benfits_;
using flutterApi.DTOs.Insurance;
using flutterApi.Models;
using System.ComponentModel.DataAnnotations;

namespace flutterApi.DTOs.CompanyInfo
{
    public class UpdateCompanyInfoDto
    {
        public int CompanyInfoId { get; set; }

        public int? CarModelId { get; set; }
        public List<CreateInsuranceDto> insurance { get; set; }=new List<CreateInsuranceDto>();


        // public string Type { get; set; }
        // [Required]
        // public float InsurancePrice { get; set; }
        // [Required]

       





        


        //public List<int>? Benfits { get; set; }
        //public List<string> Benfits { get; set; } = new List<string>();
    }
}
