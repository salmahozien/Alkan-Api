using System.ComponentModel.DataAnnotations;

namespace flutterApi.Models
{
    public class PriceOffers
    {
        public int PriceOffersId { get; set; }
        public string CompanyName { get; set; }
        [DataType(DataType.Currency)]
        public decimal OfferPrice { get; set; }
        
        public virtual Car   Car{ get; set; }    
        public virtual int CarId { get; set; }
    }
}
