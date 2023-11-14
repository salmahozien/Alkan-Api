using flutterApi.DTOs.Home.HomeLimitsDTOS;
using flutterApi.DTOs.Home.HomePriceDtos;
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
            var output=new ReturnHomeLimits();
            if(model == null) { output.Message = "Empty model"; }
            else
            {
                var company = await _companiesService.FindById(model.HomeCompanyId);
                if(company == null) { output.Message = "Company Not Found!"; }
                else
                {
                    var homelimit = model.Adapt<HomeLimits>();
                    if(homelimit == null) { output.Message = "Can't Add Home Limits"; }
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
      public async Task<ReturnPremiumAndTotalInstallment> GtPremiumAndTotalInstallment([Optional] double BuildingPrice,[Optional]double contentPrice, int CompanyId)
        {
            var output= new ReturnPremiumAndTotalInstallment();
            var HomeLimits = await FindAll(x => x.HomeCompanyId == CompanyId);
            foreach(var limit in HomeLimits)
            {
                if (limit.From == BuildingPrice&&limit.From==contentPrice)
                {
                    var x = new PremiumAndTotalInstallment()
                    {
                        PremiumForBuilding = limit.NetPremium,
                        TotalInstallmentForBuilding = limit.TotalInstallment,
                        PremiumForContent=limit.NetPremium,
                        TotalInstallmentForContent=limit.TotalInstallment

                    };

                    output.premiumAndTotal = x;
                    
                    
                    output.Message = string.Empty;
                    break;
                }

                if (limit.To == BuildingPrice && limit.To == contentPrice)
                {
                    var x = new PremiumAndTotalInstallment()
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
                if (limit.From < BuildingPrice && limit.To > BuildingPrice&&limit.From<contentPrice&&limit.To>contentPrice)
                {
                    var x = new PremiumAndTotalInstallment()
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
                    var x = new PremiumAndTotalInstallment()
                    {
                        PremiumForBuilding = limit.NetPremium,
                        TotalInstallmentForBuilding = limit.TotalInstallment
                    };
                    output.premiumAndTotal= x;
                    
                    output.Message = string.Empty;
                    break;
                }
                if(limit.To== BuildingPrice && contentPrice == 0)
                {
                    var x = new PremiumAndTotalInstallment()
                    {
                        PremiumForBuilding = limit.NetPremium,
                        TotalInstallmentForBuilding = limit.TotalInstallment,
                    };
                    output.premiumAndTotal= x;
                    output.Message = string.Empty;
                    break;
                }
                if (limit.From < BuildingPrice && limit.To > BuildingPrice &&  contentPrice==0)
                {
                    var x = new PremiumAndTotalInstallment()
                    {
                        PremiumForBuilding = limit.NetPremium,
                        TotalInstallmentForBuilding = limit.TotalInstallment
                    };
                    output.premiumAndTotal= x;
                    output.Message = string.Empty;
                    break;

                }

                if (limit.From < BuildingPrice && limit.To > BuildingPrice && limit.From < contentPrice && limit.To > contentPrice)
                {
                    var x = new PremiumAndTotalInstallment()
                    {
                        PremiumForBuilding = limit.NetPremium,
                    TotalInstallmentForBuilding = limit.TotalInstallment,
                    PremiumForContent = limit.NetPremium,
                    TotalInstallmentForContent = limit.TotalInstallment,};
                    output.premiumAndTotal = x;
                    output.Message = string.Empty;
                    break;
                }
                if (limit.From == contentPrice && BuildingPrice == 0)
                {
                    var x = new PremiumAndTotalInstallment()
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
                    var x = new PremiumAndTotalInstallment()
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
                    var x = new PremiumAndTotalInstallment()
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
    }
}
