using flutterApi.Models;

namespace flutterApi.DTOs.Home.HomePriceDtos
{
    public class ReturnHomePriceDto
    {
        public string ? Message { get; set; }   =string.Empty;
        public HomePrice? homePrice { get; set; }   
    }
}
