using flutterApi.DTOs.Home.HomePriceDtos;
using flutterApi.Interfaces;
using flutterApi.Models;
using login.Models;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace flutterApi.Services
{
    public class HomePriceService : BaseRepository<HomePrice>, IHomePriceService
    {
        private readonly UserManager<User> _userManager;
        private readonly IHomeCompaniesService _homeCompaniesService;
     
        private readonly IHomeLimitsService _homeLimitsService;
        public HomePriceService(ApplicationDBContext Context, UserManager<User> userManager, IHomeCompaniesService homeCompaniesService, IHomeLimitsService homeLimitsService) : base(Context)
        {
            _userManager = userManager;
            _homeCompaniesService = homeCompaniesService;
         
            _homeLimitsService = homeLimitsService;
        }

        public async  Task<ReturnHomePriceDto> AddHomePrice(CreateHomePriceDto model)
        {
            var output= new ReturnHomePriceDto();
            if(model == null) { output.Message = "Empty Model"; }
            else
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user == null) { output.Message = "User Not Found!"; }
                else
                {
                    var company = await _homeCompaniesService.FindById(model.HomeCompanyId);
                    if (company == null) { output.Message = "Company Not Found!"; }
                    else
                    {

                        var HomePrice = model.Adapt<HomePrice>();
                        if (HomePrice == null) { output.Message = "Can't Add Price"; }
                        else
                        {
                            await Add(HomePrice);
                            await CommitChanges();
                            output.homePrice = HomePrice;
                        }
                    }
                }
            }
            return output;  
        }
        public async Task<ReturnPremiumAndTotalInstallment> GetPremiumAndTotalInstallment( int HomePriceId)
        {
            var output= new ReturnPremiumAndTotalInstallment();
            var homeprice=await FindById(HomePriceId);
            if (homeprice == null) { output.Message = "Can't Find Price!"; }
            else
            {
                if (homeprice.PriceOfBuildings != null && homeprice.PriceOfTheContentOfBuilding != null)
                {
                    var x = await _homeLimitsService.GtPremiumAndTotalInstallment((double)homeprice.PriceOfBuildings, (double)homeprice.PriceOfTheContentOfBuilding, homeprice.HomeCompanyId);
                    if (x.Message != string.Empty) { output.Message = x.Message; }
                    else { output.premiumAndTotal = x.premiumAndTotal; }

                }

                    if (homeprice.PriceOfBuildings != null && homeprice.PriceOfTheContentOfBuilding == null)
                    {
                        var x = await _homeLimitsService.GtPremiumAndTotalInstallment((double)homeprice.PriceOfBuildings, 0, homeprice.HomeCompanyId);
                        if (x.Message != string.Empty) { output.Message = x.Message; }
                        else { output.premiumAndTotal = x.premiumAndTotal; }
                    }
                    if (homeprice.PriceOfBuildings == null && homeprice.PriceOfTheContentOfBuilding != null)
                    {
                        var x = await _homeLimitsService.GtPremiumAndTotalInstallment(0, (double)homeprice.PriceOfTheContentOfBuilding, homeprice.HomeCompanyId);
                        if (x.Message != string.Empty) { output.Message = x.Message; }
                        else { output.premiumAndTotal = x.premiumAndTotal; }

                    }
                }
            return output;
        }
    }
}
