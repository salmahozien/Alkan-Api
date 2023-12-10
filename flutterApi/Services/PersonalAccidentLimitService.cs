using flutterApi.DTOs.Home.HomeLimitsDTOS;
using flutterApi.DTOs.Medical.AgeLmit;
using flutterApi.DTOs.PersonalAccident.Limits;
using flutterApi.Interfaces;
using flutterApi.Models;
using login.Models;
using Mapster;

namespace flutterApi.Services
{
    public class PersonalAccidentLimitService : BaseRepository<PersonalAccidentLimit>, IPersonalAccidentLimitService
    {
        public PersonalAccidentLimitService(ApplicationDBContext Context) : base(Context)
        {
        }

        public async Task<ReturnPersonalAccidentLimit> AddPersonalAccidentLimit(CreatePersonalAccidentLimit model)
        {
            var output = new ReturnPersonalAccidentLimit();
            if (model == null)
            {
                output.Message = "Empty Model!";
            }
            else
            {
                var limit = model.Adapt<PersonalAccidentLimit>();
                if (limit == null) { output.Message = "Can't Add Limit"; }
                else
                {
                    await Add(limit);
                    await CommitChanges();
                    output.PersonalAccidentLimit = limit;
                }
            }
            return output;
        }
        public async Task<ReturnPriceDto> GetLimit(double Price, int CompanyId)
        {
            var output = new ReturnPriceDto();
            var Limits= await FindAll(x=>x.PersonalAccidentCompanyId==CompanyId);
            if (Limits.Count() == 0) { output.Message = "This Company Doesn't Has Limits"; }
            else
            {
                foreach (var item in Limits)
                {
                    if (Price == item.From)
                    {
                        if (item.NetPremium == null)
                        {
                            var x = new PriceDto()
                            {
                                Premium=null,
                                total = item.TotalInstallment 
                            };
                            output.Message = string.Empty;
                            output.Price = x; break;

                        }
                        else
                        {
                            var x = new PriceDto()
                            {
                                Premium = item.NetPremium ,
                                total = item.TotalInstallment
                            };
                            output.Message = string.Empty;
                            output.Price = x; break;
                        }
                    }

                    if (Price > item.From && Price < item.To)
                    {
                        if (item.NetPremium == null)
                        {
                            var x = new PriceDto()
                            {Premium = null,
                                total = item.TotalInstallment
                            };
                            output.Message = string.Empty;
                            output.Price = x; break;

                        }
                        else
                        {
                            var x = new PriceDto()
                            {
                                Premium = item.NetPremium,
                                total = item.TotalInstallment
                            };
                            output.Message = string.Empty;
                            output.Price = x; break;
                        }
                    }
                    if (Price == item.To)
                    {
                        if (item.NetPremium == null)
                        {
                            var x = new PriceDto()
                            {
                                Premium=null,
                                total = item.TotalInstallment
                            };
                            output.Message = string.Empty;
                            output.Price = x; break;

                        }
                        else
                        {
                            var x = new PriceDto()
                            {
                                Premium = item.NetPremium  ,
                                total = item.TotalInstallment
                            };
                            output.Message = string.Empty;
                            output.Price = x; break;
                        }
                    }
                    else { output.Message = "Wrong Personal Accident Price"; }
                }
            }
             return output;
        }

    }
}