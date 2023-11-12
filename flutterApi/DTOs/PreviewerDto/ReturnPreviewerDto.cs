namespace flutterApi.DTOs.PreviewerDto
{
    public class ReturnPreviewerDto
    {
        public string? Message { get; set; } = string.Empty;
        public List<PreviewerDto> Previewer { get; set; }
    }
}
