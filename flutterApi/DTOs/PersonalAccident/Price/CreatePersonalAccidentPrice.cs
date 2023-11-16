using flutterApi.Models;

namespace flutterApi.DTOs.PersonalAccident.Price
{
    public class CreatePersonalAccidentPrice
    {
        public double? Price { get; set; }
        public string UserId { get; set; }
        public int PersonalAccidentCompanyId { get; set; }
    }
}
