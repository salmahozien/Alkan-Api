using System.ComponentModel.DataAnnotations;

namespace flutterApi.DTOs.Register
{
    public class RegisterDto
    {
        [Required]

        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]

        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public string RegWay { get; set; }

        //[Required]
        // public bool PhoneNumberCofirmed { get; set; }
        //public string? UserName ="s" ;
        // public string? NormalizedUserName = "ss";
    }
}
