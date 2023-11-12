using flutterApi.DTOs.Sms;
using Microsoft.AspNetCore.Mvc;
using Twilio.AspNet.Core;
using Twilio.TwiML;
using Twilio.TwiML.Messaging;

namespace flutterApi.Controllers
{
    public class ReciveController : TwilioController
    {
        [HttpPost("SendReply")]
        public TwiMLResult SendReply([FromForm] SmsDto request)
        {
            var response = new MessagingResponse();
            response.Message("Hello");

            return TwiML(response);

        }
    }
}
