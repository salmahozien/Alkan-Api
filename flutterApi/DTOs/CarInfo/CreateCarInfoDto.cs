using flutterApi.DTOs.CarModel;
using flutterApi.Models;
using System.ComponentModel.DataAnnotations;

namespace flutterApi.DTOs.CarInfo
{
    public class CreateCarInfoDto
    {
        
        [Required]
        public string BrandName { get; set; }
        public List< CreateCarModelDto> carModels { get; set; }
    
    }
}
