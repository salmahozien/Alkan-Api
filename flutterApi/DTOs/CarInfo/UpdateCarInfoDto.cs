
using flutterApi.DTOs.CarModel;
using System.ComponentModel.DataAnnotations;

namespace flutterApi.DTOs.CarInfo
{
    public class UpdateCarInfoDto
    {
        public int CarInfoId { get; set; }
        [Required]
        public string BrandName { get; set; }
        public List<UpdateCarModelDto> carModels { get; set; }
    
    }
}
