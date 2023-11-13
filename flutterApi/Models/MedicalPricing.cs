namespace flutterApi.Models
{
    public class MedicalPricingData
    {
        public int MedicalPricingDataId { get; set; }
        public string Type { get; set; }
        public DateTime DateOfBirth {  get; set; }   
       
        public User User { get; set; }
        public string UserId { get; set; }

        public double Price { get; set; }

    }
}
