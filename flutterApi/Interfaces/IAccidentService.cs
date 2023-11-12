
using flutterApi.DTOs.Accident;
using flutterApi.Models;

namespace flutterApi.Interfaces
{
    public interface IAccidentService:IBaseRepository<Accident>
    {
        Task<accidentdto> AddAccident(CreateAccidentDto model);
        Task<Accident> UpdateAccident(UpdateAccidentDto model);
        Task<Accident> DeleteAccident(UpdateAccidentDto model);
        Task<ReturnAccidentPhotoDto> UploadImage(IFormFile file, int PolicyId);
        Task<ImageAccidentDB> GetImage(string ImageName);

    }
}
