
using flutterApi.DTOs.CarInfo;
using flutterApi.Interfaces;
using flutterApi.Models;
using login.Models;
using Mapster;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace flutterApi.Services
{
    public class CarInfoService:BaseRepository<CarInfo>,ICarInfoService
    {
        private readonly ICarModelService _CarModelService;
        public CarInfoService(ApplicationDBContext Context, ICarModelService CarModelService) : base(Context)
        {
         _CarModelService=CarModelService;
        }

        public async Task<CarInfo> AddCarInfo(CreateCarInfoDto model)
        {



            if (model == null) { return null; }

            var CarInfo = model.Adapt<CarInfo>();
            if (CarInfo == null)
            {
                return null;
            }
            

            await Add(CarInfo);
            await CommitChanges();
           
            return CarInfo;


        }

        public async Task<CarInfo> DeleteCarInfo(UpdateCarInfoDto model)
        {
            if (model == null) { return null; }
            var CarInfo = await FindById(model.CarInfoId);
            if (CarInfo == null)
            {
                return null;
            }
            await Delete(CarInfo);
            await CommitChanges();
            return CarInfo;
        }

        public async Task<CarInfo> UpdateCarInfo(UpdateCarInfoDto model)
        {
            if (model == null) { return null; }
            var CarInfo = await FindByIdWithData(model.CarInfoId);
            if (CarInfo == null) { return null; }
            CarInfo = model.Adapt<CarInfo>();
            if (CarInfo == null) { return null; }
         
            await Update(CarInfo);
            await CommitChanges();
            return CarInfo;
        }

        public async Task<List<CarInfo>> GetCarModels( string BrandName)
        {
            if (BrandName == null)
            {
                return null;
            }
            var Brand= await FindAllWithData (x=>x.BrandName == BrandName);

            return (List<CarInfo>)Brand;
        }

     
    }
    
}

