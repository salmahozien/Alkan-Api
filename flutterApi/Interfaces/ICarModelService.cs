using flutterApi.DTOs.CarModel;

using flutterApi.Models;

namespace flutterApi.Interfaces
{
    public interface ICarModelService:IBaseRepository<CarModel>
    {
        Task<CarModel> AddCarModel(CreateCarModelDto model);
        Task<CarModel> UpdateCarModel(UpdateCarModelDto model);
        Task<CarModel> DeleteCarModel(UpdateCarModelDto model);
    }
}
