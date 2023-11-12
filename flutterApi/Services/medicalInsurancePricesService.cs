using flutterApi.DTOs.Medical.AgeLmit.MedicalInsurancePriceDto;
using flutterApi.Interfaces;
using flutterApi.Models;
using login.Models;
using Mapster;

namespace flutterApi.Services
{
    public class medicalInsurancePricesService : BaseRepository<MedicalInsurancePrice>, ImedicalInsurancePricesService
    {
        public medicalInsurancePricesService(ApplicationDBContext Context) : base(Context)
        {
        }

        public async Task<ReturnMedicalInsurancePrice> AddMedicalInsurancePrice(CreateMedicalInsurancePriceDto model)
        {
           var output= new ReturnMedicalInsurancePrice();
            if(model ==null) { output.Message = "Empty Model"; }
            else
            {
                var MedicalPrice= model.Adapt<MedicalInsurancePrice>();
                if(MedicalPrice==null) { output.Message = "Can't Add Model"; }
                else
                {
                    await Add(MedicalPrice);
                    await CommitChanges();
                    output.MedicalInsurancePrice= MedicalPrice;
                }
            }
            return output;
        }
    }
}
