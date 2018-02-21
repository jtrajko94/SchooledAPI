using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchooledAPI.Utilities
{
    public class Email : EmailMessage
    {
        public Email()
        {
            Server = Settings.EmailServer;
            Username = Settings.EmailUsername;
            Password = Settings.EmailPassword;
            Port = Settings.EmailPort;
            SSL = Settings.EmailSsl;
            FromAddress = Settings.EmailFromAddress;
        }

        public void GetEmailAddresses(string group, out string[] toList, out string[] ccList, out string[] bccList, bool isLocal)
        {
            toList = new string[] { "jerunt@gmail.com" };
            ccList = null;
            bccList = null;
            return;
        }

        private static string[] parseEmail(string email)
        {
            var returnList = new List<string>();

            if (email != null)
            {
                if (email.Contains(","))
                {
                    foreach (var e in email.Split(','))
                    {
                        if (!string.IsNullOrEmpty(e))
                        {
                            returnList.Add(e.Trim());
                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(email.Trim()))
                    {
                        returnList.Add(email.Trim());
                    }
                }
            }

            return returnList.ToArray();
        }
    }
}