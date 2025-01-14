﻿using flutterApi.DTOs.Home.HomeLimitsDTOS;
using flutterApi.DTOs.Home.HomePriceDtos;
using flutterApi.DTOs.Medical.AgeLmit;
using flutterApi.Enums;
using flutterApi.Interfaces;
using flutterApi.Models;
using login.Models;
using Mapster;
using System.Runtime.InteropServices;

namespace flutterApi.Services
{
    public class HomeLimitsService : BaseRepository<HomeLimits>, IHomeLimitsService
    {
        private readonly IHomeCompaniesService _companiesService;
        public HomeLimitsService(ApplicationDBContext Context, IHomeCompaniesService companiesService) : base(Context)
        {
            _companiesService = companiesService;
        }

        public async Task<ReturnHomeLimits> AddHomeLimits(CreateHomeLimitsDto model)
        {
            var output = new ReturnHomeLimits();
            if (model == null) { output.Message = "Empty model"; }
            else
            {
                var company = await _companiesService.FindById(model.HomeCompanyId);
                if (company == null) { output.Message = "Company Not Found!"; }
                else
                {
                    var homelimit = model.Adapt<HomeLimits>();
                    if (homelimit == null) { output.Message = "Can't Add Home Limits"; }
                    else
                    {
                        await Add(homelimit);
                        await CommitChanges();
                        output.HomeLimits = homelimit;
                    }
                }
            }
            return output;
        }
        public async Task<ReturnPremiumAndTotalInstallment> GtPremiumAndTotalInstallment([Optional] double BuildingPrice, [Optional] double contentPrice, int CompanyId)
        {
            var output = new ReturnPremiumAndTotalInstallment();
            var HomeLimits = await FindAll(x => x.HomeCompanyId == CompanyId);
            foreach (var limit in HomeLimits)
            {
                if (limit.From == BuildingPrice && limit.From == contentPrice)
                {
                    var x = new PremiumAndTotalInstallmentForHome()
                    {
                        PremiumForBuilding = limit.NetPremium,
                        TotalInstallmentForBuilding = limit.TotalInstallment,
                        PremiumForContent = limit.NetPremium,
                        TotalInstallmentForContent = limit.TotalInstallment

                    };

                    output.premiumAndTotal = x;


                    output.Message = string.Empty;
                    break;
                }

                if (limit.To == BuildingPrice && limit.To == contentPrice)
                {
                    var x = new PremiumAndTotalInstallmentForHome()
                    {
                        PremiumForBuilding = limit.NetPremium,
                        TotalInstallmentForBuilding = limit.TotalInstallment,
                        PremiumForContent = limit.NetPremium,
                        TotalInstallmentForContent = limit.TotalInstallment,
                    };
                    output.premiumAndTotal = x;

                    output.Message = string.Empty;
                    break;

                }
                if (limit.From < BuildingPrice && limit.To > BuildingPrice && limit.From < contentPrice && limit.To > contentPrice)
                {
                    var x = new PremiumAndTotalInstallmentForHome()
                    {
                        PremiumForBuilding = limit.NetPremium,
                        TotalInstallmentForBuilding = limit.TotalInstallment,
                        PremiumForContent = limit.NetPremium,
                        TotalInstallmentForContent = limit.TotalInstallment
                    };
                    output.premiumAndTotal = x;
                    output.Message = string.Empty;
                    break;
                }
                if (limit.From == BuildingPrice && contentPrice == 0)
                {
                    var x = new PremiumAndTotalInstallmentForHome()
                    {
                        PremiumForBuilding = limit.NetPremium,
                        TotalInstallmentForBuilding = limit.TotalInstallment
                    };
                    output.premiumAndTotal = x;

                    output.Message = string.Empty;
                    break;
                }
                if (limit.To == BuildingPrice && contentPrice == 0)
                {
                    var x = new PremiumAndTotalInstallmentForHome()
                    {
                        PremiumForBuilding = limit.NetPremium,
                        TotalInstallmentForBuilding = limit.TotalInstallment,
                    };
                    output.premiumAndTotal = x;
                    output.Message = string.Empty;
                    break;
                }
                if (limit.From < BuildingPrice && limit.To > BuildingPrice && contentPrice == 0)
                {
                    var x = new PremiumAndTotalInstallmentForHome()
                    {
                        PremiumForBuilding = limit.NetPremium,
                        TotalInstallmentForBuilding = limit.TotalInstallment
                    };
                    output.premiumAndTotal = x;
                    output.Message = string.Empty;
                    break;

                }

                if (limit.From < BuildingPrice && limit.To > BuildingPrice && limit.From < contentPrice && limit.To > contentPrice)
                {
                    var x = new PremiumAndTotalInstallmentForHome()
                    {
                        PremiumForBuilding = limit.NetPremium,
                        TotalInstallmentForBuilding = limit.TotalInstallment,
                        PremiumForContent = limit.NetPremium,
                        TotalInstallmentForContent = limit.TotalInstallment,
                    };
                    output.premiumAndTotal = x;
                    output.Message = string.Empty;
                    break;
                }
                if (limit.From == contentPrice && BuildingPrice == 0)
                {
                    var x = new PremiumAndTotalInstallmentForHome()
                    {
                        PremiumForContent = limit.NetPremium,
                        TotalInstallmentForContent = limit.TotalInstallment
                    };
                    output.premiumAndTotal = x;
                    output.Message = string.Empty;
                    break;
                }
                if (limit.To == contentPrice && BuildingPrice == 0)
                {
                    var x = new PremiumAndTotalInstallmentForHome()
                    {
                        PremiumForContent = limit.NetPremium,
                        TotalInstallmentForContent = limit.TotalInstallment,
                    };
                    output.premiumAndTotal = x;
                    output.Message = string.Empty;
                    break;
                }
                if (limit.From < contentPrice && limit.To > contentPrice && BuildingPrice == 0)
                {
                    var x = new PremiumAndTotalInstallmentForHome()
                    {
                        PremiumForBuilding = limit.NetPremium,
                        TotalInstallmentForBuilding = limit.TotalInstallment,
                    };
                    output.premiumAndTotal = x;

                    output.Message = string.Empty;
                    break;

                }

                else
                {
                    output.Message = "Wrong Age";
                }

            }
            return output;

        }

        public async Task<ReturnPriceDto> GetPrice(double Price, int CompanyId, string type)
        {
            var output = new ReturnPriceDto();


            
            var company = await _companiesService.FindById(CompanyId);

            
                if (company.Code == HomeCompanies.Orient.ToString())
                {
                    var result = await GetPriceORient(Price, CompanyId);
                if (result.Message != string.Empty) { output.Message= result.Message; }
                else { output.Price = result.Price; }
                }
                if(company.Code==HomeCompanies.MIC.ToString())
            {
                var result = await GetPriceMIC(Price, CompanyId);
                if (result.Message != string.Empty) { output.Message = result.Message; }
                else { output.Price = result.Price; }
            }
             
           if(company.Code == HomeCompanies.GIG.ToString())
            {
                var result= await GetPriceGIG(Price, CompanyId,type);
                if (result.Message != string.Empty) { output.Message = result.Message; }
                else { output.Price = result.Price; }
            }

          
            return output;

       }
        public async Task<ReturnPriceDto> GetPriceORient(double Price,int CompanyId)
        {
            var HomeLimits = await FindAll(x => x.HomeCompanyId == CompanyId);
            var output = new ReturnPriceDto();
            foreach (var item in HomeLimits)
            {
                if (item.From == Price)
                {
                    var x = new PriceDto()
                    {
                        Premium = item.NetPremium ,
                        total = item.TotalInstallment ,

                    };
                    output.Price = x;
                    output.Message = string.Empty;
                    break;
                }

                if (item.To == Price)
                {
                    var x = new PriceDto()
                    {
                        Premium = item.NetPremium ,
                        total = item.TotalInstallment 

                    };
                    output.Price = x;
                    output.Message = string.Empty;
                    break;

                }
                if (item.From < Price && item.To > Price)
                {
                    var x = new PriceDto()
                    {
                        Premium = item.NetPremium ,
                        total = item.TotalInstallment 

                    };
                    output.Price = x;
                    output.Message = string.Empty;
                    break;
                }
                else
                {
                    output.Message = "No limit Found";
                }
            }
            return output;      
        }

        public async Task<ReturnPriceDto> GetPriceMIC(double Price, int CompanyId)
        {
            var output = new ReturnPriceDto();
            var HomeLimits = await FindAll(x => x.HomeCompanyId == CompanyId);
            foreach (var item in HomeLimits)
            {
                if (item.From == Price)
                {
                    var x = new PriceDto()
                    {
                        Premium = (int?)(Price * .0015),
                        total = item.TotalInstallment

                    };
                    output.Price = x;
                    output.Message = string.Empty;
                    break;
                }

                if (item.To == Price)
                {
                    var x = new PriceDto()
                    {
                        Premium = (int?)(Price * .0015),
                        total = item.TotalInstallment

                    };
                    output.Price = x;
                    output.Message = string.Empty;
                    break;

                }
                if (item.From < Price && item.To > Price)
                {
                    var x = new PriceDto()
                    {
                        Premium = (int?)(Price * .0015),
                        total = item.TotalInstallment

                    };
                    output.Price = x;
                    output.Message = string.Empty;
                    break;
                }
            }

            return output;
        }
        public async Task<ReturnPriceDto> GetPriceGIG(double Price, int CompanyId, string Type)
        {
            var output = new ReturnPriceDto();
            var HomeLimits = await FindAll(x => x.HomeCompanyId == CompanyId);

            if (Type == "Building")
            {


                foreach (var item in HomeLimits)
                {
                    if (item.From == Price)
                    {
                        var x = new PriceDto()
                        {
                            Premium = (int?)(Price * .0005),
                            total = item.TotalInstallment

                        };
                        output.Price = x;
                        output.Message = string.Empty;
                        break;
                    }

                    if (item.To == Price)
                    {
                        var x = new PriceDto()
                        {
                            Premium = (int?)(Price * .0005),
                            total = item.TotalInstallment

                        };
                        output.Price = x;
                        output.Message = string.Empty;
                        break;

                    }
                    if (item.From < Price && item.To > Price)
                    {
                        var x = new PriceDto()
                        {
                            Premium = (int?)(Price * .0005),
                            total = item.TotalInstallment 

                        };
                        output.Price = x;
                        output.Message = string.Empty;
                        break;
                    }
                    else
                    {
                        output.Message = "No limit Found";
                    }
                }
            }
            else
            {
                foreach (var item in HomeLimits)
                {
                    if (item.From == Price)
                    {
                        var x = new PriceDto()
                        {
                            Premium = (int?)(Price * .0025),
                            total = item.TotalInstallment

                        };
                        output.Price = x;
                        output.Message = string.Empty;
                        break;
                    }

                    if (item.To == Price)
                    {
                        var x = new PriceDto()
                        {
                            Premium = (int?)(Price * .0025),
                            total = item.TotalInstallment

                        };
                        output.Price = x;
                        output.Message = string.Empty;
                        break;

                    }
                    if (item.From < Price && item.To > Price)
                    {
                        var x = new PriceDto()
                        {
                            Premium = (int?)(Price * .0025),
                            total = item.TotalInstallment

                        };
                        output.Price = x;
                        output.Message = string.Empty;
                        break;
                    }
                    else
                    {
                        output.Message = "No limit Found";
                    }
                }
            }
            return output;

        }


    }
}
