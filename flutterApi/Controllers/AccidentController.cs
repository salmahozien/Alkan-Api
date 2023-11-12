
using flutterApi.DTOs.Accident;
using flutterApi.Interfaces;
using flutterApi.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace flutterApi.Controllers
{
    [Route("Accident/[action]")]
    public class AccidentController : Controller
    {
        private readonly IAccidentService _AccidentService;
        public AccidentController(IAccidentService AccidentService)
        {
            _AccidentService = AccidentService;
        }

        [HttpPost]

        public async Task<IActionResult> AddAccident(CreateAccidentDto model)
        {


           
            
                var NewAccident = await _AccidentService.AddAccident(model);
            if(NewAccident.Message!=string.Empty||NewAccident.UpdateAccident==null ) {
                return BadRequest(NewAccident.Message);
            }


            return Ok(NewAccident.UpdateAccident);





        }
        [HttpGet]
        public async Task<IActionResult> GetAccidentById(int id)
        {

            var Accident = await _AccidentService.FindById(id);
            if (Accident == null)
            {
                return NotFound("Accident Not Found");
            }
            return Ok(Accident);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAccidents()
        {
            var Accidents = await _AccidentService.GetAll();
            if (Accidents != null || !Accidents.Any())
            {
                var result = Accidents.Adapt<IEnumerable<UpdateAccidentDto>>().ToList(); ;


                return Ok(result);
            }
            // var newAccident = new List<IEnumerable<CreateAccidentDto>>();
            return NotFound(Accidents);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAccidents([FromBody] UpdateAccidentDto model)
        {
            var Accident = await _AccidentService.FindById(model.AccidentId);
            if (Accident == null)
            {
                return NotFound(" this Accident Not Found");
            }
            var UpdatedAccident = await _AccidentService.UpdateAccident(model);
            if (UpdatedAccident == null)
            {
                return BadRequest(" Accident not updated");
            }
            else
            {
                return Ok(UpdatedAccident);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAccident([FromBody] UpdateAccidentDto model)
        {
            var Accident = await _AccidentService.FindById(model.AccidentId);
            if (Accident == null)
            {
                return NotFound("Accident Not Found");
            }
            var DeletedAccident = await _AccidentService.DeleteAccident(model);

            return Ok("Accident  Deleted");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAccidentById([FromBody] int id)
        {

            var Accident = await _AccidentService.FindById(id);
            if (Accident == null) { return NotFound("Accident Not Found"); }
            await _AccidentService.Delete(Accident);
            await _AccidentService.CommitChanges();
            return Ok("AccidentDeleted");
        }
        //[HttpGet]
        //public async Task<Accident> GETPHONE(string ID)
        //{
        //    if (string.IsNullOrEmpty(ID)) { return null; }
        //    var phone = await _AccidentService.Find(x=>x.UserId==ID);
        //    return phone;
        //}

     /*   [HttpPost]
        public Response UploadFile([FromForm] FileModel fileModel)
        {
            Response response = new Response();
            try
            {
                string path = Path.Combine(@"E:\\development\\MobileApps\\Mobile-Insurance-App\\Images", "Uploads");
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    fileModel.File.CopyTo(stream);
                }
                response.statusCode = 200;
                response.ErrorMessage = ("image Ceated Successfuly");
            }

            catch (Exception ex) { }
            {
                response.statusCode = 100;
                response.ErrorMessage = "sum error occured";
            }




            return response;

        }*/
        //resive from FrontEnd
        /* [HttpPost("uploadImage")]

         public async Task<IActionResult> SaveExcelSheet(IFormFile file, int id)
         {
             var result = await _AccidentService.UploadImage(file, id);
            // if (result. != string.Empty || result.ImageName == string.Empty)
            // {
              //   return BadRequest(result.Message);
            // }
             return Ok(result);
         }
        */


        [HttpGet("getImage")]
        public async Task<IActionResult> GetImage(string Name)
        {
            var image = await _AccidentService.GetImage(Name);
            return Ok(image);
        }
    }
}



