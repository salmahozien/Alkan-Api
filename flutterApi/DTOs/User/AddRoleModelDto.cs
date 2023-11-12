using Microsoft.Build.Framework;

namespace flutterApi.DTOs.User
{
    public class AddRoleModelDto
    {
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
