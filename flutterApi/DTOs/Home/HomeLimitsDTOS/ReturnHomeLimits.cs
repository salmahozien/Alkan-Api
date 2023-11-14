using flutterApi.Models;

namespace flutterApi.DTOs.Home.HomeLimitsDTOS
{
    public class ReturnHomeLimits
    {
        public string? Message { get; set; } = string.Empty;
        public HomeLimits? HomeLimits { get; set; } 
    }
}
