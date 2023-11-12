using flutterApi.DTOs.InsuranceRequests;
using flutterApi.Interfaces;
using flutterApi.Models;
using login.Models;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace flutterApi.Services
{
    public class InsuranceRequestService : BaseRepository<InsuranceRequest>, IInsuranceRequestService
    {
        private readonly UserManager<User> _userManager;
        public InsuranceRequestService(ApplicationDBContext Context, UserManager<User> userManager) : base(Context)
        {
            _userManager = userManager;
        }

        public async Task<ReturnInsuranceRequestDto> AddInsuranceRequest(InsuranceRequestDto model)
        {
            var output= new ReturnInsuranceRequestDto();
            if(model == null) { output.Message = "empty Model"; }
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null) { output.Message = "user Not Found!"; }
            else
            {


                var InsuranceRequest = model.Adapt<InsuranceRequest>();

                if (InsuranceRequest == null) { output.Message = "Error in model"; }
                else
                {
                    await Add(InsuranceRequest);
                    await CommitChanges();
                    output.InsuranceRequest=InsuranceRequest.Adapt<InsuranceRequestDto>();
                }
            }
            return output;

        }
        public async Task<ReturnInsuranceRequestDto> GetInsuranceRequestById(int id)
        {
            var output = new ReturnInsuranceRequestDto();
            var request= await FindById(id);
            if(request==null) { output.Message = "Insurance Request Not Found"; }
            else
            {
                output.InsuranceRequest=request.Adapt<InsuranceRequestDto>();
            }

            return output;
        }
        public async Task<ReturnInsuranceRequestDto> DeleteInsuranceRequestById(int id)
        {
            var output= new ReturnInsuranceRequestDto();
            var request= await FindById(id);
            if(request ==null) { output.Message = "Insurance Request Not Found"; }
            else
            {
                await Delete(request);
                await CommitChanges();
                output.Message = "Request Deleted";
            }
            return output;
        }

        public async Task<ReturnInsuranceRequestDto> EditInsuranceRequest(UpdateInsuranceRequestDto model)
        {
            var output = new ReturnInsuranceRequestDto();
            var Request = await FindById(model.InsuranceRequestId);
            if (Request == null) { output.Message = "This Insurance Request Not Found"; }
            else
            {
                var Updates=model.Adapt<InsuranceRequest>();
                await Update(Request);
                await CommitChanges();
                output.InsuranceRequest = Updates.Adapt<InsuranceRequestDto>();
            }
            return output;
            
        }
    }
}
