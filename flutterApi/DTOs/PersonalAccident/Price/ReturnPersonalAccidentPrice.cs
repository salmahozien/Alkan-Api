using flutterApi.Models;

namespace flutterApi.DTOs.PersonalAccident.Price
{
    public class ReturnPersonalAccidentPrice
    {
        public string? Message { get; set; } = string.Empty;
        public PersonalAccidentPrice? PersonalAccidentPrice { get; set;}
    }
}
