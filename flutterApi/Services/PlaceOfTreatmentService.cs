using flutterApi.DTOs.Medical.PlacesOfTreatment;
using flutterApi.Interfaces;
using flutterApi.Models;
using login.Models;
using Mapster;

namespace flutterApi.Services
{
    public class PlaceOfTreatmentService : BaseRepository<PlaceOfTreatment>, IPlaceOfTreatmentService
    {
        private readonly IMedicalCompanyService _medicalCompanyService;
        public PlaceOfTreatmentService(ApplicationDBContext Context, IMedicalCompanyService medicalCompanyService) : base(Context)
        {
            _medicalCompanyService = medicalCompanyService;
        }

        public async Task<ReturnPlaceOfTreatment> AddPlaceOfTreatment(CreatePlaceOfTreatment model)
        {
            var output = new ReturnPlaceOfTreatment();
            if (model == null) { output.Message = "Empty Model!"; }
            else
            {
                var PlaceOfTreatment = model.Adapt<PlaceOfTreatment>();
                if (PlaceOfTreatment == null) { output.Message = "Can't Add Place Of Treatment"; }
                else
                {
                    await Add(PlaceOfTreatment);
                    await CommitChanges();
                    output.PlaceOfTreatment = PlaceOfTreatment;
                }

            }
            return output;
        }

        public async Task<ReturnListPlaceOfTreatment> GetAllPlaceOfTreatmentByCompanyId(int companyId)
        {
            var output= new ReturnListPlaceOfTreatment();
            var AllPlaces= await FindAll(x=>x.MedicalCompanyId==companyId);
            var Company = await _medicalCompanyService.FindById(companyId);
            if (Company == null) { output.Message = "Company Not Found !"; }
            else
            {
                if (AllPlaces.Count() == 0) { output.Message = "This Company Don't Have Place Of Treatment"; }
                else
                {
                    foreach(var item in AllPlaces)
                    {
                        output.PlaceOfTreatment.Add(item);
                    }

                }
            }
            return output;
        }
    }
}
