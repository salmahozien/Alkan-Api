using flutterApi.Helpers;
using flutterApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Security.Cryptography;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;

namespace flutterApi.Services
{
    public class SMSService : ISMSService
    {
        private readonly TwilioSettings _twilioSettings;

        public SMSService(IOptions<TwilioSettings >twilioSettings)
        {
            _twilioSettings = twilioSettings.Value;
        }

        public MessageResource Send(string MobileNumber, string Body)
        {
           

            var random = RandomNumberGenerator.Create();
            var bytes = new byte[4]; // 4 bytes
            random.GetNonZeroBytes(bytes);
            var result2 = BitConverter.ToInt32(bytes);





            //var rand = new Random();
            // var bytes = new byte[4];
            //int randomLessThan100 =rand.Next(0,5);
            TwilioClient.Init(_twilioSettings.AccountSID,_twilioSettings.AuthToken);
            var result = MessageResource.Create(
                body: result2.ToString(),
                from:new Twilio.Types.PhoneNumber(_twilioSettings.TwilioPhoneNumber),
                to:MobileNumber
                ) ;
            return result ;
        }
        public MessageResource Recive(string MobileNumber, string Body)
        {
            // string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            //  string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");
            TwilioClient.Init(_twilioSettings.AccountSID, _twilioSettings.AuthToken);

           // TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Fetch(pathSid: "MM800f449d0399ed014aae2bcc0cc2f2ec");
            return message;
        }





        }
        
        }

