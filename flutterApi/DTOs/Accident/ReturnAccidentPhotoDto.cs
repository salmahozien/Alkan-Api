using System.Security.Policy;

namespace flutterApi.DTOs.Accident
{
    public class ReturnAccidentPhotoDto
    {
        public string ?Message { get; set; }=string.Empty;
        public string ?ImageName { get; set; } = string.Empty;
    }
}
