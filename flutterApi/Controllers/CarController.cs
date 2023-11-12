using flutterApi.DTOs.Product;
using flutterApi.DTOs.ProductDto;
using flutterApi.Interfaces;
using flutterApi.Models;
using flutterApi.Services;
using login.DTOs;
using login.Models;
using Mapster;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace flutterApi.Controllers
{
    [Route("Car/[action]")]
    [ApiController]
    public class CarController : Controller
    {
        private readonly ICarService _CarService;
        public CarController(ICarService CarService)
        {
            _CarService = CarService;
        }

        [HttpPost]

        public async Task<IActionResult> AddCar([FromBody] CreateCarDto model)
        {
            //if(model== null) { return null; }

            if (ModelState.IsValid)
            {
                var NewCar = await _CarService.AddCar(model);

                if (NewCar == null) { return BadRequest("plz fill all Required fields"); }
                return Ok(NewCar);
            }
            return BadRequest(ModelState);
            //var user= _db.Users.Where(x=>x.Id==Newproduct.userId).FirstOrDefault();




        }
        [HttpGet]
        public async Task<IActionResult> GetCarById(int id)
        {

            var Car = await _CarService.FindById(id);
            if (Car == null)
            {
                return NotFound("Car Not Found");
            }
            return Ok(Car);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var Cars = await _CarService.GetAll();
            if (Cars != null || !Cars.Any())
            {
                var result = Cars.Adapt<IEnumerable<UpdateCarDto>>().ToList(); ;


                return Ok(result);
            }
            var newCars = new List<IEnumerable<CreateCarDto>>();
            return NotFound(newCars);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCars([FromBody] UpdateCarDto model)
        {
            var Car = await _CarService.FindById(model.CarId);
            if (Car == null)
            {
                return NotFound(" this Car Not Found");
            }
            var UpdatedCar = await _CarService.UpdateCar(model);
            if (UpdatedCar == null)
            {
                return BadRequest(" Car not updated");
            }
            else
            {
                return Ok(UpdatedCar);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCar([FromBody] UpdateCarDto model)
        {
            var Car = await _CarService.FindById(model.CarId);
            if (Car == null)
            {
                return NotFound("Car Not Found");
            }
            var DeletedCar = await _CarService.DeleteCar(model);

            return Ok("Car  Deleted");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCarById(int id)
        {

            var Car = await _CarService.FindById(id);
            if (Car == null) { return NotFound("Car Not Found"); }
            await _CarService.Delete(Car);
            await _CarService.CommitChanges();
            return Ok("Car Deleted");
        }
    }
}


        // [HttpGet]
        // public async Task<IActionResult> GetCarByUser( int userID){


        //}
       
