using login.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace flutterApi.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public   string Model { get; set; }
        [Required]
        [DataType(DataType.Date)
]
        public string ManufacturingYear { get; set; }
        [Required]
   
        public int CarPrice { get; set; }
       
        public virtual ICollection<User>? users { get; set;}=new HashSet<User>();
        public virtual ICollection<PriceOffers>? PriceOffers { get; set; } = new HashSet<PriceOffers>();
    }

}
