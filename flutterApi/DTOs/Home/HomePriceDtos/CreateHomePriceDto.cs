namespace flutterApi.DTOs.Home.HomePriceDtos
{
    public class CreateHomePriceDto
    {
        public double? PriceOfBuildings { get; set; }
        public double? PriceOfTheContentOfBuilding { get; set; }

        public string UserId { get; set; }
        public int HomeCompanyId { get; set; }

    }
}
