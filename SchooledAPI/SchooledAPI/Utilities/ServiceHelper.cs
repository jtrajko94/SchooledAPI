using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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