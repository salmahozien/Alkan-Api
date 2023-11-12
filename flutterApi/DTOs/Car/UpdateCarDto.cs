using System.ComponentModel.DataAnnotations;

namespace flutterApi.DTOs.Product
{
    public class UpdateCarDto
    {
        public int CarId { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [DataType(DataType.Date)
]
        public string ManufacturingYear { get; set; }
        [Required]

        public int CarPrice { get; set; }


        public string? userId { get; set; }
    }
}
