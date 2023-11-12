using flutterApi.DTOs.CarModel;
using flutterApi.DTOs.Company_Benfits_;
using flutterApi.Interfaces;
using flutterApi.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace flutterApi.Controllers
{
    [Route("CarModel/[action]")]
    public class CarModelController : Controller
    {
        private readonly ICarModelService _CarModelService;

        public CarModelController(ICarModelService CarModelService)
        {
            _CarModelService = CarModelService;
        }
        [HttpPost]

        public async Task<IActionResult> AddCarModel([FromBody] CreateCarModelDto model)
        {
            //if(model== null) { return null; }

            if (ModelState.IsValid)
            {
                var NewCarModel = await _CarModelService.AddCarModel(model);

                if (NewCarModel == null) { return BadRequest("plz fill all Required fields"); }
                return Ok(NewCarModel);
            }
            return BadRequest(ModelState);
            //var user= _db.Users.Where(x=>x.Id==Newproduct.userId).FirstOrDefault();




        }
        [HttpGet]
        public async Task<IActionResult> GetCompanyCarModelById(int id)
        {

            var CarModel = await _CarModelService.FindById(id);
            if (CarModel == null)
            {
                return NotFound("CarModel Not Found");
            }
            return Ok(CarModel);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCarModel()
        {
            var CarModels = await _CarModelService.GetAll();
            if (CarModels != null || !CarModels.Any())
            {
                var result = CarModels.Adapt<IEnumerable<UpdateCarModelDto>>().ToList(); ;


                return Ok(result);
            }
            var newCarModel = new List<IEnumerable<CreateCarModelDto>>();
            return NotFound(newCarModel);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCarModel([FromBody] UpdateCarModelDto model)
        {
            var CarModel = await _CarModelService.FindById(model.CarModelId);
            if (CarModel == null)
            {
                return NotFound(" this Car Model Not Found");
            }
            var UpdatedCarModel = await _CarModelService.UpdateCarModel(model);
            if (UpdatedCarModel == null)
            {
                return BadRequest(" Car Model not updated");
            }
            else
            {
                return Ok(UpdatedCarModel);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCarModel([FromBody] UpdateCarModelDto model)
        {
            var CarModel = await _CarModelService.FindById(model.CarModelId);
            if (CarModel == null)
            {
                return NotFound("Car Model Not Found");
            }
            var DeletedCarModel = await _CarModelService.DeleteCarModel(model);

            return Ok("Car Model Deleted");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCarModelById(int id)
        {

            var CarModel = await _CarModelService.FindById(id);
            if (CarModel == null) { return NotFound("Car Model Not Found"); }
            await _CarModelService.Delete(CarModel);
            await _CarModelService.CommitChanges();
            return Ok("Car Model Deleted");
        }

    }
}

 