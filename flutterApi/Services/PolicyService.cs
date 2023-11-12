using flutterApi.DTOs.Policy;
using flutterApi.DTOs.Product;
using flutterApi.DTOs.ProductDto;
using flutterApi.Interfaces;
using flutterApi.Models;
using login.Models;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Linq.Expressions;

namespace flutterApi.Services
{
    public class PolicyService : BaseRepository<Policy>, IPolicyService

    {
        private readonly UserManager<User> _userManager;
        public PolicyService(ApplicationDBContext Context, UserManager<User> userManager) : base(Context)
        {
            _userManager = userManager;
        }

        public async Task<Policy> AddPolicy(CreatePolicyDto model)
        {
            if (model == null) { return null; }

            var Policy = model.Adapt<Policy>();
            if (Policy == null)
            {
                return null;
            }
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null) { return null; }
            _userManager.Adapt(user);


            await Add(Policy);
            await CommitChanges();
           


            await Update(Policy);
            CommitChanges();
            return Policy;



        }

        public async Task<Policy> DeletePolicy(UpdatePolicyDto model)
        {
            if (model == null) { return null; }
            var Policy = await FindById(model.PolicyId);
            if (Policy == null)
            {
                return null;
            }
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null) { return null; }
            _userManager.Adapt(user);

            await Delete(Policy);
            await CommitChanges();
            return Policy;

        }

        public async Task<Policy> UpdatePolicy(UpdatePolicyDto model)
        {
            if (model == null) { return null; }
            var Policy = await FindByIdWithData(model.PolicyId);
            if (Policy == null) { return null; }
            Policy = model.Adapt<Policy>();
            if (Policy == null) { return null; }
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null) { return null; }
            _userManager.Adapt(user);
           // Policy.User.Add(user);

            await Update(Policy);
            await CommitChanges();
            return Policy;

        }
        public async Task<List<Policy>> GetAllUserPolice(string id)
        {
            var Policies = await FindAll(x => x.UserId == id);
            if(Policies .Count(x=>x.UserId==id)==0)
            {
                return null;
            }
            return Policies.ToList();


         
        }



    }
}