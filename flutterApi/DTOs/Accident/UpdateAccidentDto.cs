using System.ComponentModel.DataAnnotations;

namespace flutterApi.DTOs.Accident
{
    public class UpdateAccidentDto
    {
        public int AccidentId { get; set; }
       // [DataType(DataType.Url)]
        //location
        public string AccidentLocation { get; set; }
        [DataType(DataType.MultilineText)]
        public string Details { get; set; }
        //images
       // [DataType(DataType.Upload)]
        public string Images { get; set; }
        public string UserId { get; set; }
        public int PolicyId { get; set; }

    }
}
