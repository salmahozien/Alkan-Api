using login.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

using Microsoft.EntityFrameworkCore;
using flutterApi.Helpers;
using flutterApi.DTOs.personalimagesDto;
using flutterApi.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace flutterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalImagesController : ControllerBase
    {
    
            private readonly IWebHostEnvironment environment;
            private readonly ApplicationDBContext context;
        public PersonalImagesController(IWebHostEnvironment environment, ApplicationDBContext context)
            {
                this.environment = environment;
                this.context = context;
            }
    
            [HttpPost("UploadImage")]
            public async Task<IActionResult> UploadImage(IFormFile formFile, string userId)
            {
            APIResponse response = new APIResponse();
                try
                {
                    string Filepath = GetFilepath(userId);
                    if (!System.IO.Directory.Exists(Filepath))
                    {
                        System.IO.Directory.CreateDirectory(Filepath);
                    }

                    string imagepath = Filepath + "\\" + userId + ".png";
                    if (System.IO.File.Exists(imagepath))
                    {
                        System.IO.File.Delete(imagepath);
                    }
                    using (FileStream stream = System.IO.File.Create(imagepath))
                    {
                        await formFile.CopyToAsync(stream);
                        response.ResponseCode = 200;
                        response.Result = "pass";
                    }
                }
                catch (Exception ex)
                {
                    response.Errormessage = ex.Message;
                }
                return Ok(response);
            }

            [HttpPut("MultiUploadImage")]
            public async Task<IActionResult> MultiUploadImage(IFormFileCollection filecollection, string userId)
            {
                APIResponse response = new APIResponse();
                int passcount = 0; int errorcount = 0;
                try
                {
                    string Filepath = GetFilepath(userId);
                    if (!System.IO.Directory.Exists(Filepath))
                    {
                        System.IO.Directory.CreateDirectory(Filepath);
                    }
                    foreach (var file in filecollection)
                    {
                        string imagepath = Filepath + "\\" + file.FileName;
                        if (System.IO.File.Exists(imagepath))
                        {
                            System.IO.File.Delete(imagepath);
                        }
                        using (FileStream stream = System.IO.File.Create(imagepath))
                        {
                            await file.CopyToAsync(stream);
                            passcount++;

                        }
                    }


                }
                catch (Exception ex)
                {
                    errorcount++;
                    response.Errormessage = ex.Message;
                }
                response.ResponseCode = 200;
                response.Result = passcount + " Files uploaded &" + errorcount + " files failed";
                return Ok(response);
            }

            [HttpGet("GetImage")]
            public async Task<IActionResult> GetImage(string userId)
            {
                string Imageurl = string.Empty;
                string hosturl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                try
                {
                    string Filepath = GetFilepath(userId);
                    string imagepath = Filepath + "\\" + userId + ".png";
                    if (System.IO.File.Exists(imagepath))
                    {
                        Imageurl = hosturl + "/Upload/userId/" + userId + "/" + userId + ".png";
                    }
                    
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {
                }
                return Ok(Imageurl);

            }

            [HttpGet("GetMultiImage")]
            public async Task<IActionResult> GetMultiImage(string userId)
            {
                List<string> Imageurl = new List<string>();
                string hosturl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                try
                {
                    string Filepath = GetFilepath(userId);

                    if (System.IO.Directory.Exists(Filepath))
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(Filepath);
                        FileInfo[] fileInfos = directoryInfo.GetFiles();
                        foreach (FileInfo fileInfo in fileInfos)
                        {
                            string filename = fileInfo.Name;
                            string imagepath = Filepath + "\\" + filename;
                            if (System.IO.File.Exists(imagepath))
                            {
                                string _Imageurl = hosturl + "/Upload/product/" + userId + "/" + filename;
                                Imageurl.Add(_Imageurl);
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                }
                return Ok(Imageurl);

            }

            [HttpGet("download")]
            public async Task<IActionResult> download(string userId)
            {
                // string Imageurl = string.Empty;
                //string hosturl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                try
                {
                    string Filepath = GetFilepath(userId);
                    string imagepath = Filepath + "\\" + userId + ".png";
                    if (System.IO.File.Exists(imagepath))
                    {
                        MemoryStream stream = new MemoryStream();
                        using (FileStream fileStream = new FileStream(imagepath, FileMode.Open))
                        {
                            await fileStream.CopyToAsync(stream);
                        }
                        stream.Position = 0;
                        return File(stream, "image/png", userId + ".png");
                        //Imageurl = hosturl + "/Upload/product/" + productcode + "/" + productcode + ".png";
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {
                    return NotFound();
                }


            }

            [HttpGet("remove")]
            public async Task<IActionResult> remove(string userId)
            {
                // string Imageurl = string.Empty;
                //string hosturl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                try
                {
                    string Filepath = GetFilepath(userId);
                    string imagepath = Filepath + "\\" + userId + ".png";
                    if (System.IO.File.Exists(imagepath))
                    {
                        System.IO.File.Delete(imagepath);
                        return Ok("pass");
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {
                    return NotFound();
                }


            }

            [HttpGet("multiremove")]
            public async Task<IActionResult> multiremove(string userId)
            {
                // string Imageurl = string.Empty;
                //string hosturl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                try
                {
                    string Filepath = GetFilepath(userId);
                    if (System.IO.Directory.Exists(Filepath))
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(Filepath);
                        FileInfo[] fileInfos = directoryInfo.GetFiles();
                        foreach (FileInfo fileInfo in fileInfos)
                        {
                            fileInfo.Delete();
                        }
                        return Ok("pass");
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {
                    return NotFound();
                }


            }

            [HttpPost("DBMultiUploadImage")]
            public async Task<IActionResult> DBMultiUploadImage(IFormFileCollection filecollection, string userId)
            {
                APIResponse response = new APIResponse();
                int passcount = 0; int errorcount = 0;
                try
                {
                    foreach (var file in filecollection)
                    {
                        using (MemoryStream stream = new MemoryStream())
                        {
                            await file.CopyToAsync(stream);
                            this.context.PersonalImages.Add(new Models.PersonalImage()
                            {
                                UserId = userId,
                                Idcard = stream.ToArray(),
                                PersonalDrivingLicense = stream.ToArray(),
                                CarLicense = stream.ToArray(),

                            });
                            await this.context.SaveChangesAsync();
                            passcount++;
                        }
                    }


                }
                catch (Exception ex)
                {
                    errorcount++;
                    response.Errormessage = ex.Message;
                }
                response.ResponseCode = 200;
                response.Result = passcount + " Files uploaded &" + errorcount + " files failed";
                return Ok(response);
            }



        

        [HttpGet("GetDBMultiImage")]
            public async Task<IActionResult> GetDBMultiImage(string userId)
            {
                List<string> Imageurl = new List<string>();
                //string hosturl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                try
                {
                    var _Personalimage = this.context.PersonalImages.Where(item => item.UserId == userId).ToList();
                    if (_Personalimage != null && _Personalimage.Count > 0)
                    {
                        _Personalimage.ForEach(item =>
                        {
                            Imageurl.Add(Convert.ToBase64String(item.Idcard));
                            Imageurl.Add(Convert.ToBase64String(item.PersonalDrivingLicense));
                            Imageurl.Add(Convert.ToBase64String(item.CarLicense));
                        });
                    }
                    else
                    {
                        return NotFound();
                    }
                    //string Filepath = GetFilepath(productcode);

                    //if (System.IO.Directory.Exists(Filepath))
                    //{
                    //    DirectoryInfo directoryInfo = new DirectoryInfo(Filepath);
                    //    FileInfo[] fileInfos = directoryInfo.GetFiles();
                    //    foreach (FileInfo fileInfo in fileInfos)
                    //    {
                    //        string filename = fileInfo.Name;
                    //        string imagepath = Filepath + "\\" + filename;
                    //        if (System.IO.File.Exists(imagepath))
                    //        {
                    //            string _Imageurl = hosturl + "/Upload/product/" + productcode + "/" + filename;
                    //            Imageurl.Add(_Imageurl);
                    //        }
                    //    }
                    //}

                }
                catch (Exception ex)
                {
                }
                return Ok(Imageurl);

            }


            [HttpGet("dbdownload")]
            public async Task<IActionResult> dbdownload(string userId)
            {

                try
                {

                    var _Personalimage = await this.context.PersonalImages.FirstOrDefaultAsync(item => item.UserId == userId);
                    if (_Personalimage != null)
                    {

                        return File(_Personalimage.CarLicense, "image/png", userId + ".png");
                    }


                    //string Filepath = GetFilepath(productcode);
                    //string imagepath = Filepath + "\\" + productcode + ".png";
                    //if (System.IO.File.Exists(imagepath))
                    //{
                    //    MemoryStream stream = new MemoryStream();
                    //    using (FileStream fileStream = new FileStream(imagepath, FileMode.Open))
                    //    {
                    //        await fileStream.CopyToAsync(stream);
                    //    }
                    //    stream.Position = 0;
                    //    return File(stream, "image/png", productcode + ".png");
                    //    //Imageurl = hosturl + "/Upload/product/" + productcode + "/" + productcode + ".png";
                    //}
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {
                    return NotFound();
                }


            }

            [NonAction]
            private string GetFilepath(string userId)
            {
                return this.environment.WebRootPath + "\\Upload\\userId\\" + userId;
            }

        }
}


