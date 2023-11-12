using flutterApi.DTOs.Sms;
using flutterApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twilio.AspNet.Core;
using Twilio.TwiML;

namespace flutterApi.Controllers
{
    [Route("SMS/[action]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly ISMSService _smsservice;

        public SMSController(ISMSService smsservice)
        {
            _smsservice = smsservice;
        }

        [HttpPost]
        public  IActionResult Send(SmsDto dto)
        {
            var result = _smsservice.Send(dto.MobileNumber, dto.Body);
            if (!string.IsNullOrEmpty(result.ErrorMessage))
                return BadRequest(result.ErrorMessage);

            return Ok(result);
        }
      /* [HttpPost]

        public IActionResult recive(ReciveDto dto )
            
        {
             var msg=MessageResource.Read(limit: 20);

            var result= _smsservice.Equals(dto.Body);
            if(result==null) { return BadRequest("Correct Msg"); }
            return Ok(result);


        }
      */

    }
}
