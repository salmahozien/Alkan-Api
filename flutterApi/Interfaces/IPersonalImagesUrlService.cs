using flutterApi.DTOs.Accident;
using flutterApi.DTOs.PersonalImagesUrls;
using flutterApi.Models;

namespace flutterApi.Interfaces
{
    public interface IPersonalImagesUrlService:IBaseRepository<personalImagesUrl>
    {
        Task<ReturnPersonalImagesUrl> AddPersonalImagesUrl(personalImagesUrlDtos personalImagesUrl);
        Task<ReturnAccidentPhotoDto> UploadImage(IFormFile file, string UserId);
          
    }
}
