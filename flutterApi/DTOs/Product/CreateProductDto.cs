using System.ComponentModel.DataAnnotations;

namespace flutterApi.DTOs.ProductDto
{
    public class CreateProductDto
    {
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public DateTime ManufacturingYear { get; set; }
        public string? userId { get; set; }
    }
}
