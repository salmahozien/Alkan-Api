using System.Security.Policy;

namespace flutterApi.DTOs.PersonalImagesUrls
{
    public class personalImagesUrlDtos
    {
        public IFormFile IdCard { get; set; }

        public IFormFile PersonalDrivingLicense { get; set; }
        public IFormFile CarLicense { get; set; }
        

        public string UserId { get; set; }
    }
}
