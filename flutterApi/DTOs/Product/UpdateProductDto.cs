using System.ComponentModel.DataAnnotations;

namespace flutterApi.DTOs.Product
{
    public class UpdateProductDto
    {
        public int ProductId { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [DataType(DataType.Date)
]
        public DateTime ManufacturingYear { get; set; }
       

      
        public string? userId { get; set; }
    }
}
