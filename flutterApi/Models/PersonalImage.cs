using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace flutterApi.Models
{
    public partial class PersonalImage
    {
        [Key]
        public int Id { get; set; }
        public User Users { get; set; }

        public string UserId { get; set; }

        [Column("IDCard", TypeName = "image")]
        public byte[] Idcard { get; set; } = null!;
        [Column(TypeName = "image")]
        public byte[] PersonalDrivingLicense { get; set; } = null!;
        [Column(TypeName = "image")]
        public byte[] CarLicense { get; set; } = null!;
    }
}
