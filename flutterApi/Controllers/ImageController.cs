using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace flutterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Upload()
        {


            if (Request.ContentType is null || !Request.ContentType.Contains("multipart/form-data"))
            {
                return BadRequest(new { err = "Error Content Type" });
            }
            var filesFromClient = Request.Form.Files;
            if (!filesFromClient.Any())
            {
                return BadRequest(new { err = "No File Found" });
            }
            var file = filesFromClient[0];
            var allowedExtensions = new String[] { ".jpg", ".svg", ".png","jpeg" };
            //اتاكد ان هي صوره
            if (!allowedExtensions.Any(x => file.FileName.EndsWith(x, StringComparison.InvariantCultureIgnoreCase)))
            {
                return BadRequest(new { err = "no file extension" });
            }
            if (file.Length > 1000000)
            {
                return BadRequest(new { err = "max size exceeded" });
            }
            if (file.Length < 0)
            {
                return BadRequest(new { err = "Empty File" });

            }
            // var fileName=$"{Guid.NewGuid()}_{file.FileName}";
            // E:\development\MobileApps\Mobile - Insurance - App\flutterApi - Deploy\flutterApi\Uploads\Images
            var ProjectFolder = Directory.GetCurrentDirectory();
            var relativeImagePath = Path.Combine("Assets", "Images");
            var FullImagePath = Path.Combine(ProjectFolder, relativeImagePath);
            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var fullFilePath = Path.Combine(FullImagePath, fileName);
            // Using==>end connection(fileStream) with database(Call Dispose)
            using (var stream = new FileStream(fullFilePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            //baseurl 
            var url = $"{Request.Scheme}:// {Request.Host}/Assets/Images/{fileName}";
            return Ok(new { Url = url });

        }
    }
}
