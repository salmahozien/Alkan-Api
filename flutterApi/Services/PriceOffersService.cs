using flutterApi.Models;
using login.Models;

namespace flutterApi.Services
{
    public class PriceOffersService : BaseRepository<PriceOffers>
    {
        public PriceOffersService(ApplicationDBContext Context) : base(Context)
        {
        }
    }
}
