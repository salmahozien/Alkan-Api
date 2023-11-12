using flutterApi.Interfaces;
using flutterApi.Models;
using login.Models;

namespace flutterApi.Services
{
    public class ReportImageDBService : BaseRepository<ReportImageDb>, IReportImageDBService
    {
        public ReportImageDBService(ApplicationDBContext Context) : base(Context)
        {
        }
    }
}
