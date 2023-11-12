using flutterApi.Interfaces;
using flutterApi.Models;
using login.Models;

namespace flutterApi.Services
{
    public class ImageAccidentDBService : BaseRepository<ImageAccidentDB>, IImageAccidentDBService
    {
        public ImageAccidentDBService(ApplicationDBContext Context) : base(Context)
        {
        }
    }
}
