using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace flutterApi.Models
{
    public class User : IdentityUser
    {
       

            [Required, MaxLength(20)]
            public string FirstName { get; set; } 
            [Required, MaxLength(20)]
            public string LastName { get; set; }
       public string RegWay {  get; set; }  

        public List<RefreshToken>? RefreshTokens { get; set; }

        public  virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
        public virtual ICollection<Policy> Policies { get; set; } = new HashSet<Policy>();
        public virtual ICollection<Accident> Accidents { get; set; }= new HashSet<Accident>();  
        }
    }

