using System.ComponentModel.DataAnnotations;

namespace flutterApi.DTOs.PreviewerReports
{
    public class previewerReportDto
    {
        public string? Report { get; set; }

        public string? Notes { get; set; }

        public string? Video { get; set; }

        public string images { get; set; }
    
        public int previewerReportId { get; set; }
    }
}
