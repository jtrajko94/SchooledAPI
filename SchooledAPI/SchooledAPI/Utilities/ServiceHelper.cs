using System;

namespace SchooledAPI.Utilities
{
    public static class ServiceHelper
    {
        //TODO: Change to universal email
        public static void SendError(Exception err)
        {
            var errEmil = "jerunt@gmail.com";
            var email = new Email();
            email.ToAddresses = new string[] { errEmil };
            ErrorMessage.Send(email, err);
        }
    }
}