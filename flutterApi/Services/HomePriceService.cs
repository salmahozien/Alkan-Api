using flutterApi.DTOs.Home.HomePriceDtos;
using flutterApi.Enums;
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

        public async Task<ReturnHomePriceDto> AddHomePrice(CreateHomePriceDto model)
        {
            var output = new ReturnHomePriceDto();
            if (model == null) { output.Message = "Empty Model"; }
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
        /* public async Task<ReturnPremiumAndTotalInstallment> GetPremiumAndTotalInstallment(int HomePriceId)
         {
             var output = new ReturnPremiumAndTotalInstallment();
             var homeprice = await FindById(HomePriceId);
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
         }*/
        public async Task<ReturnPremiumAndTotalInstallment> GetPremiumAndTotalInstallment(int HomePriceId)
        {
            
            var output = new ReturnPremiumAndTotalInstallment();
            var homeprice = await FindById(HomePriceId);

            if (homeprice == null) { output.Message = "Can't Find Price!"; }
            else
            {
                var company = await _homeCompaniesService.FindById(homeprice.HomeCompanyId);
                if (company.Code == HomeCompanies.GIG.ToString())
                {
                    var result = await GetPremiumAndTotalInstallmentForGIG(HomePriceId);
                    if(result.Message!=string.Empty) { output.Message=result.Message; }
                    else { output.premiumAndTotal=result.premiumAndTotal; }
                }

                

                else
                {
                    var M = string.Empty;

                    if (homeprice.PriceOfBuildings != null && homeprice.PriceOfTheContentOfBuilding != null)
                    {
                        if (homeprice.PriceOfBuildings == homeprice.PriceOfTheContentOfBuilding)
                        {

                            var price = await _homeLimitsService.GetPrice((double)homeprice.PriceOfBuildings, homeprice.HomeCompanyId, M);
                            var x = new PremiumAndTotalInstallmentForHome()
                            {
                                PremiumForBuilding = price.Price.Premium,
                                PremiumForContent = price.Price.Premium,
                                TotalInstallmentForBuilding = price.Price.total,
                                TotalInstallmentForContent = price.Price.total,
                            };
                            output.premiumAndTotal = x;
                        }
                        else
                        {
                            var priceBuilding = await _homeLimitsService.GetPrice((double)homeprice.PriceOfBuildings, homeprice.HomeCompanyId, M);
                            var x = new PremiumAndTotalInstallmentForHome()
                            {
                                PremiumForBuilding = priceBuilding.Price.Premium,
                                TotalInstallmentForBuilding = priceBuilding.Price.total,
                            };

                            var priceContent = await _homeLimitsService.GetPrice((double)homeprice.PriceOfTheContentOfBuilding, homeprice.HomeCompanyId, M);
                            x.PremiumForContent = priceContent.Price.Premium;
                            x.TotalInstallmentForContent = priceContent.Price.total;
                            output.premiumAndTotal = x;
                        }
                    }

                    if (homeprice.PriceOfBuildings != null && homeprice.PriceOfTheContentOfBuilding == null)
                    {
                        var priceBuilding = await _homeLimitsService.GetPrice((double)homeprice.PriceOfBuildings, homeprice.HomeCompanyId, M);
                        var x = new PremiumAndTotalInstallmentForHome()
                        {
                            PremiumForBuilding = priceBuilding.Price.Premium,
                            TotalInstallmentForBuilding = priceBuilding.Price.total,
                        };
                        output.premiumAndTotal = x;
                    }

                    if (homeprice.PriceOfBuildings == null && homeprice.PriceOfTheContentOfBuilding != null)
                    {
                        var priceContent = await _homeLimitsService.GetPrice((Double)homeprice.PriceOfTheContentOfBuilding, homeprice.HomeCompanyId, M);
                        var x = new PremiumAndTotalInstallmentForHome()
                        {
                            PremiumForContent = priceContent.Price.Premium,
                            TotalInstallmentForContent = priceContent.Price.total,
                        };
                        output.premiumAndTotal = x;
                    }

                }
            }
            
                return output;
            }
        public async Task<ReturnPremiumAndTotalInstallment> GetPremiumAndTotalInstallmentForGIG(int HomePriceId)
        {
            var output = new ReturnPremiumAndTotalInstallment();
            var homeprice = await FindById(HomePriceId);

            if (homeprice == null) { output.Message = "Can't Find Price!"; }
            else
            {
                if (homeprice.PriceOfBuildings != null && homeprice.PriceOfTheContentOfBuilding != null)
                {
                    var priceBuilding = await _homeLimitsService.GetPrice((double)homeprice.PriceOfBuildings, homeprice.HomeCompanyId, "Building");
                    var x = new PremiumAndTotalInstallmentForHome()
                    {
                        PremiumForBuilding = priceBuilding.Price.Premium,
                        TotalInstallmentForBuilding = priceBuilding.Price.total,

                    };
                    var PriceContent = await _homeLimitsService.GetPrice((double)homeprice.PriceOfBuildings, homeprice.HomeCompanyId, "Content");
                    x.PremiumForContent = PriceContent.Price.Premium;
                    x.TotalInstallmentForContent = PriceContent.Price.total;
                    output.premiumAndTotal = x;
                }
                if (homeprice.PriceOfBuildings != null && homeprice.PriceOfTheContentOfBuilding == null)
                {
                    var priceBuilding = await _homeLimitsService.GetPrice((double)homeprice.PriceOfBuildings, homeprice.HomeCompanyId, "Building");
                    var x = new PremiumAndTotalInstallmentForHome()
                    {
                        PremiumForBuilding = priceBuilding.Price.Premium,
                        TotalInstallmentForBuilding = priceBuilding.Price.total,

                    };
                    output.premiumAndTotal = x;
                }
                if (homeprice.PriceOfBuildings == null && homeprice.PriceOfTheContentOfBuilding != null)
                {
                    var PriceContent = await _homeLimitsService.GetPrice((double)homeprice.PriceOfBuildings, homeprice.HomeCompanyId, "Content");
                    var x = new PremiumAndTotalInstallmentForHome()
                    {
                        PremiumForContent = PriceContent.Price.Premium,
                        TotalInstallmentForContent = PriceContent.Price.total,

                    };
                    output.premiumAndTotal = x;
                }
            }
            return output;

        }
                 
            
        }
    }

