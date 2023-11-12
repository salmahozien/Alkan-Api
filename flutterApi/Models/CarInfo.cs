using Microsoft.Build.Framework;

namespace flutterApi.Models
{
    public class CarInfo
    {
        public int CarInfoId { get; set; }
        [Required]
        public string BrandName { get; set; }
        public List<CarModel> carModels { get; set; }

       

       
    }
}
