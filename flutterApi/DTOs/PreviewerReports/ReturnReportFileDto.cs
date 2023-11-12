namespace flutterApi.DTOs.PreviewerReports
{
    public class ReturnReportFileDto
    {
        public string? Message { get; set; } = string.Empty;
        public List<string>  ?File { get; set; } =new List<string>();
    }
}
