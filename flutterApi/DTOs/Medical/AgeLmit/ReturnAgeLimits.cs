using flutterApi.Models;

namespace flutterApi.DTOs.Medical.AgeLmit
{
    public class ReturnAgeLimits
    {
        public string? Message { get; set; } = string.Empty;
        public AgeLimits? AgeLimit { get; set; }
    }
}
