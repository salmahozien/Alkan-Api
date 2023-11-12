using System.ComponentModel.DataAnnotations;

namespace flutterApi.Models
{
    public class personalImagesUrl
    {
        public int personalImagesUrlId { get; set; }
        [DataType(DataType.ImageUrl)]
        [Required]
        public string IdCard { get; set; }
        [DataType(DataType.ImageUrl)]
        [Required]
  
       public string  PersonalDrivingLicense { get; set; }
        [DataType(DataType.ImageUrl)]
        [Required]
        public string  CarLicense { get; set; }
        public User Users { get; set; }

        public string UserId { get; set; }
    }
}
