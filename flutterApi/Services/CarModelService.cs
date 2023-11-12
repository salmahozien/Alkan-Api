
using flutterApi.DTOs.CarModel;
using flutterApi.Interfaces;
using flutterApi.Models;
using login.Models;
using Mapster;

namespace flutterApi.Services
{
    public class CarModelService:BaseRepository<CarModel>,ICarModelService
    {
        public CarModelService(ApplicationDBContext Context) : base(Context)
        {
        }

        public async Task<CarModel> AddCarModel(CreateCarModelDto model)
        {

            if (model == null) { return null; }

            var CarModel = model.Adapt<CarModel>();
            if (CarModel == null)
            {
                return null;
            }
            


            await Add(CarModel);
            await CommitChanges();

            return CarModel;
        }

        public async Task<CarModel> DeleteCarModel(UpdateCarModelDto model)
        {
            if (model == null) { return null; }
            var CarModel = await FindById(model.CarModelId);
            if (CarModel == null)
            {
                return null;
            }
            await Delete(CarModel);
            await CommitChanges();
            return CarModel;
        }

        public async Task<CarModel> UpdateCarModel(UpdateCarModelDto model)
        {
            if (model == null) { return null; }
            var CarModel = await FindById(model.CarModelId);
            if (CarModel == null) { return null; }
            CarModel = model.Adapt<CarModel>();
            if (CarModel == null) { return null; }
            


            await Update(CarModel);
            await CommitChanges();
            return CarModel;
        }
    }
}

