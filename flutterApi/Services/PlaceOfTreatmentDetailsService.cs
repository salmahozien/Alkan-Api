using flutterApi.DTOs.Medical.PlacesOfTreatmentDetails;
using flutterApi.Interfaces;
using flutterApi.Models;
using login.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace flutterApi.Services
{
    public class PlaceOfTreatmentDetailsService : BaseRepository<PlaceOfTreatmentDetails>, IPlaceOfTreatmentDetailsService
    {
        private readonly IPlaceOfTreatmentService _placeOfTreatmentService;
        private readonly ApplicationDBContext _dbContext;
        public PlaceOfTreatmentDetailsService(ApplicationDBContext Context, IPlaceOfTreatmentService placeOfTreatmentService) : base(Context)
        {
            _placeOfTreatmentService = placeOfTreatmentService;
            _dbContext = Context;
        }

        public async Task<ReturnPlaceOfTreatmentDetails> AddPlaceOfTreatmentDetails(CreatePlaceOfTreatmentDetailsDto model)
        {
            var output = new ReturnPlaceOfTreatmentDetails();
            if (model == null) { output.message = "Empty Model"; }
            else
            {
                var placeDetails = model.Adapt<PlaceOfTreatmentDetails>();

                if (placeDetails == null) { output.message = "Can't Add Details"; }
                else
                {
                    await Add(placeDetails);
                    await CommitChanges();
                    output.placeOfTreatmentDetails = placeDetails;
                }
            }
            return output;
        }

        public async  Task<ReturnListPlaceOfTreatmentDetails> GetDetailsOfOnePlaceTreatment(int id)
        {
            var output= new ReturnListPlaceOfTreatmentDetails();
            var PlaceOfTreatment = await _placeOfTreatmentService.FindById(id);
            if(PlaceOfTreatment == null) {output.message= "Place Of Treatment Not Found!"; }
            else
            {
                var Details= 
                    _dbContext.PlaceOfTreatmentDetails.Where(x=>x.PlaceOfTreatmentId==id).Include(x=>x.typesMedicalDetails).ToList();
                if (Details.Count() == 0)
                {
                    output.message = " This Place Don't Have Details";
                }
                else
                {
                    foreach(var Detail in Details)
                    {
                        output.placeOfTreatmentDetails.Add(Detail);
                    }
                }
            }
            return output;
        }

        public async Task<ReturnNameAndStatusDto> GetDetailsOfOnePlaceTreatmentByType(int Placeid, int TypeId)
        {
            var output = new ReturnNameAndStatusDto();
            var AllService = await FindAll(x=>x.PlaceOfTreatmentId== Placeid);
            if (AllService.Count() == 0) { output.Message = "No Place Found!"; }
            else
            {
                foreach (var service in AllService)
                {


                    var Details = _dbContext.typesMedicalDetails.Where(x => x.PlaceOfTreatmentDetailsId == service.PlaceOfTreatmentDetailsId && x.CompanyHealthInsuranceTypesId == TypeId).FirstOrDefaultAsync();
                    if (Details.Result == null) { output.Message = "This Place Dos'nt Have Service "; }
                    else
                    {


                        var x = new ReturnNameAndStatus()
                        {
                            Name = service.Name,
                            Status = Details.Result.Status,
                        };

                        output.NameAndStatus.Add(x);
                    }

                }
            }
            return output;
        }
    }
}
