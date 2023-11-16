using flutterApi.DTOs.Home.HomePriceDtos;
using flutterApi.DTOs.PersonalAccident.Price;
using flutterApi.Interfaces;
using flutterApi.Models;
using login.Models;
using Mapster;

namespace flutterApi.Services
{
    public class PersonalAccidentPriceService : BaseRepository<PersonalAccidentPrice>, IPersonalAccidentPriceService
    {
        private readonly IPersonalAccidentLimitService _personalAccidentLimitService;
        private readonly IPersonalAccidentCompanyService _personalAccidentCompanyService;
        public PersonalAccidentPriceService(ApplicationDBContext Context, IPersonalAccidentLimitService personalAccidentLimitService, IPersonalAccidentCompanyService personalAccidentCompanyService) : base(Context)
        {
            _personalAccidentLimitService = personalAccidentLimitService;
            _personalAccidentCompanyService = personalAccidentCompanyService;
        }

        public async Task<ReturnPersonalAccidentPrice> AddPersonalAccidentPrice(CreatePersonalAccidentPrice model)
        {
            var output= new ReturnPersonalAccidentPrice();
            if (model == null) { output.Message = "Empty Model"; }
            else
            {
                
                
                    var Price = model.Adapt<PersonalAccidentPrice>();
                    if (Price == null) { output.Message = "Can't Add Model"; }
                    else
                    {
                        await Add(Price);
                        await CommitChanges();
                        output.PersonalAccidentPrice = Price;
                    }
                
            }
            return output;
        }
        public async Task<ReturnPermiumAndTotalForPersonal> GetPremiumAndTotalInstallment(int PersonalAccidentPriceId)
        { 
            var output=new ReturnPermiumAndTotalForPersonal();
            var amount= await FindById(PersonalAccidentPriceId);
            if (amount == null) { output.Message = "Can't Find Price"; }
            else
            {
                if (amount.Price == null) { output.Message = "Price Not Found"; }
                else {
                    var company = await _personalAccidentCompanyService.FindById(amount.PersonalAccidentCompanyId);
                    if (company == null) { output.Message = "Company Not Found!"; }
                    else {
                        var Price = await _personalAccidentLimitService.GetLimit((double)amount.Price, company.PersonalAccidentCompanyId);
                        if (Price.Message == string.Empty)
                        {
                            var x = new PermiumAndTotalForPersonalAccident()
                            {
                                NetPermium = Price.Price.Premium,
                                TotalInstallment = Price.Price.total
                            };

                            output.permiumAndTotal = x;
                        }
                        else { output.Message = Price.Message; }


                   
                       

                    }
                }
            }
                return output;
            }


        }
}
