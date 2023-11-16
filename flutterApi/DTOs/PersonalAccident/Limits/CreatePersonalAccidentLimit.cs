using flutterApi.Models;

namespace flutterApi.DTOs.PersonalAccident.Limits
{
    public class CreatePersonalAccidentLimit
    {
        public int From { get; set; }
        public int To { get; set; }
      
        public int PersonalAccidentCompanyId { get; set; }
    }
}
