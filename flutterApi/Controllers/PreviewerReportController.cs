using flutterApi.DTOs.PreviewerReports;
using flutterApi.Interfaces;
using flutterApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace flutterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreviewerReportController : ControllerBase
    {
        private readonly IPreviewerReportService _previewerReportService;
        private readonly UserManager<User>_userManager;

        public PreviewerReportController(IPreviewerReportService previewerReportService, UserManager<User> userManager)
        {
            _previewerReportService = previewerReportService;
            _userManager = userManager;
        }

        [HttpPost("addPreviewerReport")]
        public async Task<IActionResult> AddPreviewerReport([FromForm]CreatePreviewerReportDto model)
        {
            var report=await _previewerReportService.AddReport(model);
            if(report.Message!=string.Empty|| report.PreviewerReports==null) {
            return BadRequest(report.Message);
            }
            return Ok(report.PreviewerReports);
        }
        [HttpGet("GetPreviewerReports")]
        public async Task<IActionResult> GetAllPreviewersReports()
        {

            var Reports = await _previewerReportService.GetAll();
                  if(Reports==null|| Reports.Any())
            {
                return  BadRequest("No Report Found  ");
            }
            return Ok(Reports);
        }
        [HttpGet("GetPreviewerReportByID")]
        public async Task<IActionResult> GetPreviewerReportByID( int id)
        {
            var PreviewerReport= await _previewerReportService.GetPreviewerReportByID(id);
            if(PreviewerReport.Message!=string.Empty||PreviewerReport.PreviewerReports==null) {
                return BadRequest(PreviewerReport.Message);    
            }

            return Ok(PreviewerReport.PreviewerReports); 
           
        }
        [HttpGet("GetAllPreviwer")]
        public async Task<IActionResult> GetAllPreviwer()
        {
            var Previewers = await _userManager.GetUsersInRoleAsync("Previewer");
            if (Previewers == null) { return BadRequest("No Previewet Found"); }
            return Ok(Previewers);

        }

    }
}
