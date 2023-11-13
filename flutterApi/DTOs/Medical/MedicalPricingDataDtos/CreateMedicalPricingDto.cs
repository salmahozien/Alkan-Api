using flutterApi.Models;

namespace flutterApi.DTOs.Medical.MedicalPricingDataDtos
{
    public class CreateMedicalPricingDataDto
    {
        public string Type { get; set; }
        public DateTime DatOfBirth { get; set; }
       
    
        public string UserId { get; set; }

        public double Price { get; set; }
    }
}
