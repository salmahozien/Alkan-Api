﻿using System.ComponentModel.DataAnnotations;

namespace flutterApi.DTOs.ProductDto
{
    public class CreateCarDto
    {
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string ManufacturingYear { get; set; }
        public string? userId { get; set; }
        [Required]

        public int CarPrice { get; set; }
    }
}
