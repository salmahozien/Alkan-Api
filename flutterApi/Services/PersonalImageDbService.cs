using flutterApi.Interfaces;
using flutterApi.Models;
using login.Models;

namespace flutterApi.Services
{
    public class PersonalImageDbService : BaseRepository<PersonalImagesDB>,IPersonalImagedbService
    {
        public PersonalImageDbService(ApplicationDBContext Context) : base(Context)
        {
        }
    }
}
