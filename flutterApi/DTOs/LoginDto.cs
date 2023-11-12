using flutterApi.Models;
using System.ComponentModel.DataAnnotations;

namespace login.DTOs
{
    public class LoginDto
    {
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

      //  public string UserId { get;  }
    }

}
