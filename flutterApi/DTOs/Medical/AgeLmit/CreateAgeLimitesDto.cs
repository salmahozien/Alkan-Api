using flutterApi.Models;

namespace flutterApi.DTOs.Medical.AgeLmit
{
    public class CreateAgeLimitesDto
    {
        public int From { get; set; }
        public int To { get; set; }

        public int MedicalCompanyId { get; set; }
    }
}
