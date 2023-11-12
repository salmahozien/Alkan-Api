using flutterApi.DTOs.Accident;
using flutterApi.DTOs.PersonalImagesUrls;
using flutterApi.Interfaces;
using flutterApi.Models;
using login.Models;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace flutterApi.Services
{
    public class PersonalImagesUrlService : BaseRepository<personalImagesUrl>, IPersonalImagesUrlService
    {
        private readonly UserManager<User> _userManager;
        private readonly IAccidentService _accidentService;
        private readonly IPersonalImagedbService _personalImagedbservice;
        public PersonalImagesUrlService(ApplicationDBContext Context, UserManager<User> userManager, IAccidentService accidentService , IPersonalImagedbService personalImagedbservice) : base(Context)
        {
            _userManager = userManager;
            _accidentService = accidentService;
            _personalImagedbservice = personalImagedbservice;
        }

        public async Task<ReturnPersonalImagesUrl> AddPersonalImagesUrl(  personalImagesUrlDtos model)
        
        {
            var output= new ReturnPersonalImagesUrl();
            if (model == null) { output.Message = "empty model"; }
                var user = await _userManager.FindByIdAsync(model.UserId);
                if(user==null) { output.Message = " User Not Found"; }
                else
                {
                var IdCardImage = await UploadImage(model.IdCard,model. UserId);
                var PersonalDrivingLicenseImage= await UploadImage(model.PersonalDrivingLicense,model. UserId);
                var carLicenseImage= await UploadImage(model.CarLicense,model. UserId);
                var Personal = new personalImagesUrl()
                {
                    IdCard = IdCardImage.ImageName,
                    PersonalDrivingLicense = PersonalDrivingLicenseImage.ImageName,
                    CarLicense = carLicenseImage.ImageName,
                    UserId = model.UserId
                };
                    if(Personal==null) { output.Message = " error adding personalImages"; }
                    else
                    {
                        await Add(Personal);
                        await CommitChanges();
                    output.personalImage = Personal.Adapt<personalImagesUrl>();
                       
                    }
                }

            
            return output;
           
        }
        public async Task<ReturnAccidentPhotoDto> UploadImage(IFormFile file, string UserId)
        {
            var output = new ReturnAccidentPhotoDto();
            var ImageName = await WriteImage(file, UserId);
            if (ImageName.Message == string.Empty || ImageName.ImageName != string.Empty)
            {
                // await SaveImage(FileName.ImageName, PolicyId);
                output.ImageName = ImageName.ImageName;
                var Id = await _personalImagedbservice.Find(x => x.ImageName == ImageName.ImageName);
                output.ImageName = Id.ImageName;
            }

            else
            {
                output.Message = ImageName.Message;
            }

            return output;

        }

        private async Task<ReturnAccidentPhotoDto> WriteImage(IFormFile file, String UserId)
        {

            string exactpath = "";
            var output = new ReturnAccidentPhotoDto();
            var ImageType = new String[] { ".jpg", ".svg", ".png", ".jpeg" };
          

            string ext = Path.GetExtension(file.FileName);

            bool isValidType = false;

            if ( ImageType.Contains(ext))
         
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
                var user = await _userManager.FindByIdAsync(UserId);


                string ImageName = user.PhoneNumber + file.Name+ " " + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + ext;
                try
                {
                    var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                    

                    var ImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\PersonalImages");

                    if (!Directory.Exists(ImagePath))
                    {
                        Directory.CreateDirectory(ImagePath);
                    }

                    exactpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\PersonalImages", ImageName);
                    using (var stream = new FileStream(exactpath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);

                    }
                    PersonalImagesDB AddImage = new PersonalImagesDB()
                    {
                        ImageName = ImageName,
                        ImagePath = ImagePath,
                        UserId=UserId



                    };
                    await _personalImagedbservice.Add(AddImage);
                    await _personalImagedbservice.CommitChanges();

                }
                catch (Exception ex)
                {
                }

                output.ImageName = ImageName;

            }

            return output;
        }



    
    }
}
