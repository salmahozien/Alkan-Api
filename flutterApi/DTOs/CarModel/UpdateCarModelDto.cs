using System.ComponentModel.DataAnnotations;

namespace flutterApi.DTOs.CarModel
{
    public class UpdateCarModelDto
    {
        public int CarModelId { get; set; }
        [Required]
        public string ModelName { get; set; }
    
    }
}
