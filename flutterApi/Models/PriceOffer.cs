using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace flutterApi.Models
{
    [Index("CarId", Name = "IX_PriceOffers_CarId")]
    public partial class PriceOffer
    {
        [Key]
        public int PriceOffersId { get; set; }
        public string CompanyName { get; set; } = null!;
        [Column(TypeName = "decimal(18, 2)")]
        public decimal OfferPrice { get; set; }
        public int CarId { get; set; }

        [ForeignKey("CarId")]
        [InverseProperty("PriceOffers")]
        public virtual Car Car { get; set; } = null!;
    }
}
