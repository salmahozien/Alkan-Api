using flutterApi.DTOs.Images;
using System.ComponentModel.DataAnnotations;

namespace flutterApi.DTOs.PreviewerReports
{
    public class CreatePreviewerReportDto
    {

       
        public IFormFile Report { get; set; }
      
        public string Notes { get; set; }
     

        public IFormFile Video { get; set; }

  
        public IFormFile Images { get; set; }
       // public List<IFormFile> Images { get; set; } = new List<IFormFile>();
      
        public string UserId { get; set; }
    }
}
