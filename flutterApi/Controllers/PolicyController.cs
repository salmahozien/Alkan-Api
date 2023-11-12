using flutterApi.DTOs.Policy;
using flutterApi.DTOs.Product;
using flutterApi.DTOs.ProductDto;
using flutterApi.Interfaces;
using flutterApi.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace flutterApi.Controllers
{
    [Route("Policy/[Action]")]
    public class PolicyController : Controller
    {
        private readonly IPolicyService _PolicyService;

        public PolicyController(IPolicyService policyService)
        {
            _PolicyService = policyService;
        }

       
        [HttpPost]

        public async Task<IActionResult> AddPolicy([FromBody]CreatePolicyDto model)
        {
            //if(model== null) { return null; }

            if (ModelState.IsValid)
            {
                var NewPolicy = await _PolicyService.AddPolicy(model);
                if (NewPolicy == null) { return BadRequest("plz fill all Required fields"); }
                return Ok(NewPolicy);
            }
            return BadRequest(ModelState);
            //var user= _db.Users.Where(x=>x.Id==Newproduct.userId).FirstOrDefault();




        }
        [HttpGet]
        public async Task<IActionResult> GetPolicyById(int id)
        {

            var Policy = await _PolicyService.FindById(id);
            if (Policy == null)
            {
                return NotFound("Policy Not Found");
            }
            return Ok(Policy);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPolicies(  )
        {
            var Policies = await _PolicyService.GetAll();
            if (Policies != null || !Policies.Any())
            {
                var result = Policies.Adapt<IEnumerable<UpdatePolicyDto>>().ToList(); ;


                return Ok(result);
            }
            var newPolicies = new List<IEnumerable<CreatePolicyDto>>();
            return NotFound(newPolicies);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePolicy([FromBody] UpdatePolicyDto model)
        {
            var Policy = await _PolicyService.FindById(model.PolicyId);
            if (Policy == null)
            {
                return NotFound(" this Policy Not Found");
            }
            var UpdatedPolicy = await _PolicyService.UpdatePolicy(model);
            if (UpdatedPolicy == null)
            {
                return BadRequest(" Policy not updated");
            }
            else
            {
                return Ok(UpdatedPolicy);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePolicy([FromBody] UpdatePolicyDto model)
        {
            var Policy = await _PolicyService.FindById(model.PolicyId);
            if (Policy == null)
            {
                return NotFound("Policy Not Found");
            }
            var DeletedPolicy = await _PolicyService.DeletePolicy(model);

            return Ok("Policy  Deleted");
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePolicyById(int id)
        {

            var Policy = await _PolicyService.FindById(id);
            if (Policy == null) { return NotFound("Policy Not Found"); }
            await _PolicyService.Delete(Policy);
            await _PolicyService.CommitChanges();
            return Ok("Policy Deleted");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserPolice( string id)
        {
            var policies= await _PolicyService.GetAllUserPolice(id);
            if(policies == null) { return BadRequest("No Policy FouND"); }
            
                var result = policies.Adapt<IEnumerable<UpdatePolicyDto>>().ToList();


                return Ok(result);
            
          
            
        }
    }
}
