using Shop.DataAccess;
using Shop.Services.Abstract;
using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;


namespace Shop.Services
{
    public class SmsVerification : IRegistration
    {
        private const string accountSid = "AC61ec6b4768cca686cceff1e85ba028d4";
        private const string authToken = "165e4bedc94ce14bc0254f0e278f4add";
        private static Random random = new Random();

        public int SendCode(string phoneNumber)
        {
            var verificationCode = random.Next(1000, 10000);

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: $"Your verification code: {verificationCode}",
                from: new Twilio.Types.PhoneNumber("+13342747989"),
                to: new Twilio.Types.PhoneNumber("+77075141968")
            );
            return verificationCode;
        }
    }
}
