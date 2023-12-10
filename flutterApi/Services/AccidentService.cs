using flutterApi.DTOs.Accident;
using flutterApi.Interfaces;
using flutterApi.Models;
using login.Models;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using ProductMiniApi.Repository.Abastract;
using System.Security.Claims;

namespace flutterApi.Services
{
    public class AccidentService : BaseRepository<Accident>, IAccidentService
    {
        private readonly UserManager<User> _userManager;
        private readonly IPolicyService _policyService;
        private readonly IImageAccidentDBService _imageAccidentDBService;
       
        private readonly IImageAccidentDBService _imageDBService;

        public AccidentService(ApplicationDBContext Context, UserManager<User> userManager, IPolicyService policyService, IImageAccidentDBService imageDBService, IImageAccidentDBService imageAccidentDBService) : base(Context)
        {
            _userManager = userManager;

            _policyService = policyService;
            ;
            _imageDBService = imageDBService;
            _imageAccidentDBService = imageAccidentDBService;
        }

        public async Task<accidentdto> AddAccident(CreateAccidentDto model)
        {
            var output = new accidentdto();

            if (model == null) { output.Message = " empty model"; }
            else
            {
              //  var user = await _userManager.FindByIdAsync(model.UserId);

               // if (user == null) { output.Message = "user not found"; }
              //  else
              //  {
                  //  _userManager.Adapt(user);
                  //  var policy = await _policyService.FindById(model.PolicyId);
                   // if (policy == null) { output.Message = "policy not found"; }
                   // else
                  //  {

                        // Var USERPHONE = await _userManager.FindByEmailAsync(model.PhoneNumber);
                        var Image = await UploadImage(model.Images, 1);
                        if (Image.Message != string.Empty)
                        {
                            output.Message = Image.Message;
                        }

                        else
                        {
                            var Accident = new Accident()
                            {
                              //  AccidentLocation = model.AccidentLocation,
                              Latitude = model.Latitude,
                              Longitude = model.Longitude,
                               // Details = model.Details,
                                Images = Image.ImageName,
                               // PolicyId = model.PolicyId,
                              //  UserId = model.UserId



                            };
                            if (Accident == null)
                            {
                                output.Message = " empty Accident Model";
                            }





                            // await  _policyService.Add(policy);
                            else
                            {
                                await Add(Accident);
                                /// var image =  _fileService.SaveImage(model.ImageFile);
                                //await Update(Accident);


                                await CommitChanges();
                            }
                        }
                    }
              //  }
           // }

            return output;
        }

        public async Task<Accident> DeleteAccident(UpdateAccidentDto model)
        {
            if (model == null) { return null; }
            var Accident = await FindById(model.AccidentId);
            if (Accident == null)
            {
                return null;
            }
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null) { return null; }
            _userManager.Adapt(user);
            await Delete(Accident);
            await CommitChanges();
            return Accident;
        }

        public async Task<Accident> UpdateAccident(UpdateAccidentDto model)
        {
            if (model == null) { return null; }
            var Accident = await FindByIdWithData(model.AccidentId);
            if (Accident == null) { return null; }
            Accident = model.Adapt<Accident>();
            if (Accident == null) { return null; }
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null) { return null; }
            _userManager.Adapt(user);
            //var user = await _userManager.FindByIdAsync(model.AccidentId);
            //if (user == null) { return null; }
            //_userManager.Adapt(user);
            //product.users.Add(user);

            await Update(Accident);
            await CommitChanges();
            return Accident;
        }
        //    public async Task<Accident> GETPHONE(string ID)
        //    {
        //        if (string.IsNullOrEmpty(ID)) { return null; }
        //        var phone = await FindByIdWithData(ID);
        //        return phone;
        //}
        public async Task<ReturnAccidentPhotoDto> UploadImage(IFormFile file, int PolicyId)
        {
            var output = new ReturnAccidentPhotoDto();
            var FileName = await WriteImage(file, PolicyId);
            if (FileName.Message == string.Empty || FileName.ImageName != string.Empty)
            {
            // await SaveImage(FileName.ImageName, PolicyId);
                output.ImageName = FileName.ImageName;
                var Id = await _imageDBService.Find(x => x.ImageName == FileName.ImageName);
                output.ImageName = Id.ImageName;
            }

            else
            {
                output.Message = FileName.Message;
            }

            return output;

        }

        private async Task<ReturnAccidentPhotoDto> WriteImage(IFormFile file, int PolicyId)
        {

            string exactpath = "";
            var output = new ReturnAccidentPhotoDto();
            var ImageType = new String[] { ".jpg", ".svg", ".png", ".jpeg" }; 
            // string FixedFileName = "SchoolFileFormat.xlsx";
            //     var name=file.Name;
            //// if(name!= FixedFileName)
            ////  {
            ////     output.Message = "Please Download And Insert This File ";

            // }

            string ext = Path.GetExtension(file.FileName);

            bool isValidType = false;
            
                if (ImageType.Contains(ext))
                //|| ImageType.Contains("png")||ImageType.Contains("svg")||ImageType.Contains("jpeg"))
                {
                    isValidType = true;

                }
            if (isValidType == false)
            {
                output.Message =
                      "upload Image Extension .jpg - svg - png - jpeg";
            }
            else
            {
                var policy = await _policyService.FindById(PolicyId);
                if (policy == null) { output.Message = "Policy Not Found"; }

                else
                {
                    string ImageName = policy.PolicyName + file.Name + " " + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + ext;
                    try
                    {
                        var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                        // filename = DateTime.Now.Ticks.ToString() + extension;

                        var ImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images");

                        if (!Directory.Exists(ImagePath))
                        {
                            Directory.CreateDirectory(ImagePath);
                        }

                        exactpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", ImageName);
                        using (var stream = new FileStream(exactpath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);

                        }
                        ImageAccidentDB AddImage = new ImageAccidentDB()
                        {
                            ImageName = ImageName,
                            ImagePath = ImagePath,



                        };
                        await _imageDBService.Add(AddImage);
                        await _imageDBService.CommitChanges();

                    }
                    catch (Exception ex)
                    {
                    }

                    output.ImageName = ImageName;

                }
            }
            return output;
        }
public async Task<ImageAccidentDB> GetImage(string ImageName)
        {
            var imageName=await FindAll(x=>x.Images==ImageName);
            var image=await _imageAccidentDBService.Find(x=>x.ImageName==ImageName);
            
            return image ;

        }


      /*  public async Task<ReturnAccidentPhotoDto> SaveImage(string ImageName,int PolicyId)
        {

            var output=new ReturnAccidentPhotoDto();
           
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
            var allowedExtensions = new String[] { ".jpg", ".svg", ".png", "jpeg" };
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

        }*/


    }
}