using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace flutterApi.Models
{
    public class Policy
    {
        public int PolicyId { get; set; }
        [Required]
        public int policyNumber { get; set; }
        [Required]
        public string PolicyName { get; set; }
        [Required]
        public int GrossPremium { get; set; }
        [Required]
        public int  NetPremium { get;set; }
        [Required]
        public int SumInsurance { get; set; }
        public User Users { get; set; }
     
        public string UserId { get; set; }
       public virtual ICollection<Accident> Accidents { get; set; } = new HashSet<Accident>();


    }
}
