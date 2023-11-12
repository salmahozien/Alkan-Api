using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace flutterApi.DTOs.personalimagesDto
{
    public class AddPersonalimageDto
    {
        public string UserId { get; set; }

        [Column("IDCard", TypeName = "image")]
        public IFormFile Idcard { get; set; } = null!;
        [Column(TypeName = "image")]
        public IFormFile PersonalDrivingLicense { get; set; } = null!;
        [Column(TypeName = "image")]
        public IFormFile CarLicense { get; set; } = null!;
    }
}
