using flutterApi.Models;

namespace flutterApi.DTOs.PersonalAccident.Limits
{
    public class ReturnPersonalAccidentLimit
    {
        public string? Message {  get; set; }=string.Empty;
        public PersonalAccidentLimit? PersonalAccidentLimit { get; set; }
    }
}
