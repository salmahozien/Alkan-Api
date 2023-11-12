using flutterApi.Interfaces;
using flutterApi.Models;
using login.Models;

namespace flutterApi.Services
{
    public class InsuranceService : BaseRepository<Insurance>, IInsuranceService
    {
        public InsuranceService(ApplicationDBContext Context) : base(Context)
        {
        }
    }
}
