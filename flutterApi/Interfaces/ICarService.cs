using flutterApi.DTOs.Product;
using flutterApi.DTOs.ProductDto;
using flutterApi.Models;

namespace flutterApi.Interfaces
{
    public interface ICarService : IBaseRepository<Car>
    {
        Task<Car> AddCar(CreateCarDto model);
        Task<Car> UpdateCar(UpdateCarDto model);
        Task<Car> DeleteCar(UpdateCarDto model);
    }
}
