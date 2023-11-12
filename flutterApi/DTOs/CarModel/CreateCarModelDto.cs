using System.ComponentModel.DataAnnotations;

namespace flutterApi.DTOs.CarModel
{
    public class CreateCarModelDto
    {

        [Required]
        public string ModelName { get; set; }

    }
}
