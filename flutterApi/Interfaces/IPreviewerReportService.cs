using flutterApi.DTOs.PreviewerReports;
using flutterApi.Models;
using flutterApi.Services;

namespace flutterApi.Interfaces
{
    public interface IPreviewerReportService:IBaseRepository<PreviewerReport>
    {
        Task<ReturnPreviewerReport> AddReport(CreatePreviewerReportDto model);
        Task<ReturnPreviewerReport> GetPreviewerReportByID(int id);

    }
}
