using flutterApi.DTOs.Medical.MedicalPricingDataDtos;
using flutterApi.Interfaces;
using flutterApi.Models;
using login.Models;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace flutterApi.Services
{
    public class MedicalPricingDataService : BaseRepository<MedicalPricingData>, IMedicalPricingDataService
    {
        private readonly UserManager<User> _userManager;
        public MedicalPricingDataService(ApplicationDBContext Context,UserManager<User> userManager) : base(Context)
        {
            _userManager = userManager;
        }

        public async Task<ReturnMedicalPricingData> AddMedicalPricingData(CreateMedicalPricingDataDto model)
        {
            var output= new ReturnMedicalPricingData();
            if (model == null) { output.Message = "Empty Model"; }
            else
            {
                
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user == null) { output.Message = "User Not Found !"; }
                else
                {



                    var MedicalPricingData = new MedicalPricingData()
                    {
                          Type = model.Type,
                          DateOfBirth=model.DatOfBirth,
                          UserId=model.UserId,
                          CompanyHealthInsuranceTypesId=model.CompanyHealthInsuranceTypesId,
                          MedicalCompanyId=model.MedicalCompanyId



                    };
                    if (MedicalPricingData == null) { output.Message = "Can't Add"; }
                    else
                    {
                        await Add(MedicalPricingData);
                        await CommitChanges();
                        output.MedicalPricingData = MedicalPricingData;
                    }
                }
            }
            return output;
        }
    }
}
