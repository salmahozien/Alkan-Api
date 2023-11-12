using Twilio.Rest.Api.V2010.Account;

namespace flutterApi.Interfaces
{
    public interface ISMSService
    {
        MessageResource Send(string MobileNumber, String Body);
    }
}
