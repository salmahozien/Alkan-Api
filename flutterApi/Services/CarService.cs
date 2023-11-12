using flutterApi.DTOs.Product;
using flutterApi.DTOs.ProductDto;
using flutterApi.Interfaces;
using flutterApi.Models;
using login.Models;
using Mapster;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace flutterApi.Services
{
    public class CarService : BaseRepository<Car>, ICarService
    {
        private readonly UserManager<User> _userManager;


        public CarService(ApplicationDBContext Context, UserManager<User> userManager) : base(Context)
        {
            _userManager = userManager;
        }

        public async Task<Car> AddCar(CreateCarDto model)
        {
            if (model == null) { return null; }

            var Car = model.Adapt<Car>();
            if (Car == null)
            {
                return null;
            }
            var user = await _userManager.FindByIdAsync(model.userId);
            if (user == null) { return null; }
            _userManager.Adapt(user);
            

            await Add(Car);
            await CommitChanges();
            Car.users.Add(user);


            await Update(Car);
               CommitChanges();
            return Car; 

            
          
        }

        public async Task<Car> DeleteCar(UpdateCarDto model)
        {
            if (model == null) { return null; }
            var Car = await FindById(model.CarId);
            if (Car == null)
            {
                return null;
            }
            await Delete(Car);
            await CommitChanges();
            return Car;

        }

        public async Task<Car> UpdateCar(UpdateCarDto model)
        {
           if(model ==null) { return null; }
            var Car = await FindByIdWithData(model.CarId);
            if(Car == null) { return null; }
            Car = model.Adapt<Car>();
            if(Car == null) { return null;   }
            var user = await _userManager.FindByIdAsync(model.userId);
            if (user == null) { return null; }
            _userManager.Adapt(user);
            Car.users.Add(user);

            await Update(Car);
            await CommitChanges();
            return Car;

        }
       
            }

        }


    

