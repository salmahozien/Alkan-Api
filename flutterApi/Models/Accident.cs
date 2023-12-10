
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace flutterApi.Models
{
    public class Accident
    {
        public int AccidentId { get; set; }
       // [DataType(DataType.Url)]
        [Required]
        //location
        //public string AccidentLocation { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }   
      //  [DataType(DataType.MultilineText)]
       // [Required]
       // public string Details { get; set; }
        [Required]
        //images
        //  [DataType(DataType.Upload)]
       
       public string? Images { get; set; }
       // [NotMapped]
       // public IFormFile? ImageFile { get; set; }

      //  [Required]
      //  public virtual User user  { get; set; }

      
      //  public virtual string UserId { get; set; }
      //  public  virtual Policy policy { get; set; }
      
       // public  virtual int PolicyId { get; set; }

     



    }
}
