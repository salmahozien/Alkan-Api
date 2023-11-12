using flutterApi.DTOs.Accident;
using flutterApi.DTOs.PreviewerDto;
using flutterApi.DTOs.PreviewerReports;
using flutterApi.DTOs.User;
using flutterApi.Interfaces;
using flutterApi.Migrations;
using flutterApi.Models;
using login.Models;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System.Drawing;

namespace flutterApi.Services
{
    public class PreviewerReportService : BaseRepository<PreviewerReport>, IPreviewerReportService
    {
        private readonly UserManager<User> _userManager;
        private readonly IReportImageDBService _reportImageDBService;

        public PreviewerReportService(ApplicationDBContext Context, UserManager<User> userManager, IReportImageDBService reportImageDBService) : base(Context)
        {
            _userManager = userManager;
            _reportImageDBService = reportImageDBService;
        }

        public async  Task<ReturnPreviewerReport> AddReport(CreatePreviewerReportDto model)
        { var output= new ReturnPreviewerReport();

            if (model == null) { output.Message = "Empty Model"; }
            var user = await _userManager.FindByIdAsync(model.UserId);
            if(user==null) { output.Message = "Previewer Not Found"; }
            var role = await _userManager.GetRolesAsync(user);
            if (!role.Contains("Previewer")) { output.Message = "Previewer Only Can Add Report!"; }
            else
            {
                var report = await UploadFile(model);


                if (report.Message != string.Empty)
                {
                    output.Message = report.Message;
                   
                }
                else
                {
                    var reportReviewer = new PreviewerReport()
                    {
                        //////////////////
                        Notes = model.Notes,
                        Report = report.File[0],
                        Video= report.File[1],
                        images= report.File[2],
                        UserId=model.UserId,
                        
                    };
                    if (reportReviewer == null) { output.Message = "empty previewer report"; }
                
                    else
                    {
                      
                        await Add(reportReviewer);
                        await CommitChanges();
                        output.PreviewerReports = reportReviewer.Adapt<previewerReportDto>();
                        output.PreviewerReports.previewerReportId = reportReviewer.PreviewerReportId;

                       

                    }
                    
                }
            }
              
            return output;
           
        }

        public async Task<ReturnPreviewerReport> GetPreviewerReportByID(int id)
        {var output=new ReturnPreviewerReport();
            if (id == null || id == 0)
            {
                output.Message = "Wrong ID";
            }
            else
            {
               var previewerReport= await FindById(id);
                if (previewerReport == null) { output.Message = "No PreviewerFound"; }
                else
                {
                    output.PreviewerReports = previewerReport.Adapt<previewerReportDto>();
                }
            }
            return output;
        }

        public async Task<ReturnReportFileDto> UploadFile(CreatePreviewerReportDto file)
        {
            var output = new ReturnReportFileDto();
            
                var FileName = await WriteFile(file);
            if (FileName.Message == string.Empty)
            {
                foreach (var fileItem in FileName.File)
                {

                    var Id = await _reportImageDBService.Find(x => x.ReportImageDbName == fileItem);
                    if (Id == null)
                    {
                        output.Message = FileName.Message;

                    }
                    else
                    {
                        output.File .Add(fileItem);
                    }
                }
            }
            else
            {
                output.Message = FileName.Message;
            }
                
            
            return output;

        }



        private async Task<ReturnReportFileDto> WriteFile(CreatePreviewerReportDto file)
        {
            string ext;
            string exactpath = "";
            bool isValidType = false;
            List<IFormFile> files = new List<IFormFile>();
            var output = new ReturnReportFileDto();

            var ImageType = new String[] { ".jpg", ".svg", ".png", ".jpeg" };
            var ReportType = new string[] { ".pdf", ".xlsx" };
            var videoType = new String[] { ".mp3", ".mp4", ".mkv" };
            if (file == null)
            {
                output.Message = "empty model";

            }
            else
            {
                var user = await _userManager.FindByIdAsync(file.UserId);
                if (user == null) { output.Message = "user Not Found"; }
                else
                {
                    if (file.Report.Name == "Report")
                    {
                        ext = Path.GetExtension(file.Report.FileName);
                        if (ReportType.Contains(ext))
                        {
                            if (file.Video.Name == "Video")
                            {
                                ext = Path.GetExtension(file.Video.FileName);
                                if (videoType.Contains(ext))
                                {
                                    if (file.Images.Name == "Images")
                                    {
                                        ext = Path.GetExtension(file.Images.FileName);
                                        if (ImageType.Contains(ext))
                                        {
                                            isValidType = true;
                                        }
                                        else
                                        {
                                            isValidType = false;
                                            output.Message = " upload  Image Extension .jpg - svg - png - jpeg";
                                        }

                                    }
                                    else
                                    {
                                        isValidType = false;
                                        output.Message = "empty image file";
                                    }

                                }


                                else
                                {
                                    isValidType = false;
                                    output.Message = "Upload Video Extension Must be mp3 or mp4 or mkv";
                                }

                            }
                            else
                            {
                                isValidType = false;
                                output.Message = "empty video file";
                            }
                        }

                        else
                        {
                            isValidType = false;

                            output.Message = "upload Report Extension must be pdf or xlsx";
                        }

                    } 
                    else
                    {
                        isValidType = false;
                        output.Message = " Empty Report File";

                    }
                        if (isValidType== true)
                        {
                            files.Add(file.Report);
                            files.Add(file.Video);
                            files.Add(file.Images);
                            foreach (var item in files)
                            {
                                var extension = "." + item.FileName.Split('.')[item.FileName.Split('.').Length - 1];
                                string FileName = user.PhoneNumber + item.Name + " " + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + extension;
                                try
                                {
                                   

                                    var ImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\ReportImages");

                                    if (!Directory.Exists(ImagePath))
                                    {
                                        Directory.CreateDirectory(ImagePath);
                                    }

                                    exactpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\ReportImages", FileName);
                                    using (var stream = new FileStream(exactpath, FileMode.Create))
                                    {
                                        await item.CopyToAsync(stream);

                                    }
                                    ReportImageDb AddImage = new ReportImageDb()
                                    {
                                        ReportImageDbName = FileName,
                                        ReportImageDbPath = ImagePath,
                                        UserId = file.UserId



                                    };
                                    await _reportImageDBService.Add(AddImage);
                                    await _reportImageDBService.CommitChanges();
                                    output.File.Add(AddImage.ReportImageDbName.ToString());



                                }
                                catch (Exception ex)
                                {
                                }



                            } }
                        else
                        {
                            return output;
                        }
                    } } 
                    return output;

                }
      


    }
}
