using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace flutterApi.DTOs.Accident
{
    public class CreateAccidentDto
    {
       
       // [DataType(DataType.Url)]
        //location
        public string AccidentLocation { get; set; }
        [DataType(DataType.MultilineText)]
        public string Details { get; set; }
        //images
     //   [DataType(DataType.Upload)]
     [Required]
        public IFormFile Images { get; set; }
       // [NotMapped]
       // public IFormFile? ImageFile { get; set; }

        public string UserId { get; set; }
        public int PolicyId { get; set; }
        // public string PhoneNumber { get; set; }


    }
}
