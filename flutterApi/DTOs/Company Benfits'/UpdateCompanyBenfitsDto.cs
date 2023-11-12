using System.ComponentModel.DataAnnotations;

namespace flutterApi.DTOs.Company_Benfits_
{
    public class UpdateCompanyBenfitsDto
    {
        public int CompanyBenfitsId { get; set; }
       
        public string benfit { get; set; }
        

        //  public int CompanyInfoId { get; set; }
    }
}
