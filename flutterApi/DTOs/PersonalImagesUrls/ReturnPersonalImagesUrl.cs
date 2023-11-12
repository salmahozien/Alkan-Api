using flutterApi.Models;

namespace flutterApi.DTOs.PersonalImagesUrls
{
    public class ReturnPersonalImagesUrl
    {
        public string? Message { get; set; }=string.Empty;
        public personalImagesUrl? personalImage { get; set; } 
    }
}
