using flutterApi.DTOs.PreviewerReports;
using System.ComponentModel.DataAnnotations;

namespace flutterApi.Models
{
    public class PreviewerReport
    {
            public int PreviewerReportId { get; set; }
        
            public string? Report { get; set; }
       
        public string? Notes { get; set; }
       
        public string ?Video { get; set; }
        
        public string images { get; set; }
          
            public User User { get; set; }
            public string UserId { get; set; }
        
    }
}
