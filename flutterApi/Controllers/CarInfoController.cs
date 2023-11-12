
using flutterApi.DTOs.CarInfo;
using flutterApi.Interfaces;
using flutterApi.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace flutterApi.Controllers
{
    [Route("carInfo/[action]")]
    public class CarInfoController : Controller
    {
        private readonly ICarInfoService _CarInfoService;

        public CarInfoController(ICarInfoService CarInfo)
        {
            _CarInfoService = CarInfo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarInfo()
        {
            var CarInfo = await _CarInfoService.GetAllWithData();
            if (CarInfo != null || !CarInfo.Any())
            {

                var result = CarInfo.Adapt<IEnumerable<UpdateCarInfoDto>>().ToList(); ;


                return Ok(result);
            }
            var newCarInfo = new List<IEnumerable<CreateCarInfoDto>>();
            return NotFound(newCarInfo);

        }
        [HttpGet]
        public async Task<IActionResult> GetCarInfooById(int id)
        {
            var CarInfo = await _CarInfoService.FindById(id);
            if (CarInfo == null)
            {
                return NotFound("Car Info Not Found");
            }
            return Ok(CarInfo);
        }
        [HttpPost]
        public async Task<IActionResult> AddCarInfo([FromBody] CreateCarInfoDto CarInfo)
        {
            if (ModelState.IsValid)
            {
                var NewCarInfo = await _CarInfoService.AddCarInfo(CarInfo);
                if (NewCarInfo == null) { return BadRequest("plz full all Felids"); }
                return Ok(NewCarInfo);
            }
            return BadRequest(" model not valid");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCarInfo([FromBody] UpdateCarInfoDto dto)
        {
            var CarInfo = await _CarInfoService.FindById(dto.CarInfoId);
            if (CarInfo == null)
            {
                return NotFound(" this Car Info Not Found");
            }
            var UpdatedCarInfo = await _CarInfoService.UpdateCarInfo(dto);
            if (UpdatedCarInfo == null)
            {
                return BadRequest(" Car Info  not updated");
            }
            else
            {
                return Ok(UpdatedCarInfo);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCCarInfoById(int id)
        {

            var CarInfo = await _CarInfoService.FindById(id);
            if (CarInfo == null) { return NotFound("CarInfo Not Found"); }
            await _CarInfoService.Delete(CarInfo);
            await _CarInfoService.CommitChanges();
            return Ok(CarInfo);
        }
        [HttpGet]
        public async Task<IActionResult> getCarModels(String BrandName)
        {
            if (BrandName == null) return BadRequest("add Brand Name");
            var carModels= await _CarInfoService.GetCarModels(BrandName);
           if(carModels == null)
            {
                return BadRequest("This car Brand Not Found");
            }
           return Ok(carModels);
        }
      

    }
}


   
