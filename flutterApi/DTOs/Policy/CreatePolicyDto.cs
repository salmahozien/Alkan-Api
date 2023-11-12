using System.ComponentModel.DataAnnotations;

namespace flutterApi.DTOs.Policy
{
    public class CreatePolicyDto
    {
       
        [Required]
        public int policyNumber { get; set; }
        [Required]
        public string PolicyName { get; set; }
        [Required]
        public int GrossPremium { get; set; }
        [Required]
        public int NetPremium { get; set; }
        [Required]
        public int SumInsurance { get; set; }
       // public User User { get; set; }
        public string UserId { get; set; }
    }
}
