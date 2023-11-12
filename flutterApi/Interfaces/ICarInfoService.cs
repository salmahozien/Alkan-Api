
using flutterApi.DTOs.CarInfo;
using flutterApi.Models;

namespace flutterApi.Interfaces
{
    public interface ICarInfoService:IBaseRepository<CarInfo>
    {
        Task<CarInfo> AddCarInfo(CreateCarInfoDto model);

        Task<CarInfo> DeleteCarInfo(UpdateCarInfoDto model);
        Task<CarInfo> UpdateCarInfo(UpdateCarInfoDto model);
        Task<List<CarInfo> >GetCarModels(string BrandName);
    }
}
