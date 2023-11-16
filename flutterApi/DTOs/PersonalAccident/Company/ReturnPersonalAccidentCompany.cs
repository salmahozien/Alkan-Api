using flutterApi.Models;

namespace flutterApi.DTOs.PersonalAccident.Company
{
    public class ReturnPersonalAccidentCompany
    {
        public string? Message { get; set; } = string.Empty;
        public PersonalAccidentCompany? PersonalAccidentCompany { get; set;}
    }
}
