using System;
using System.Web;

namespace SchooledAPI.Utilities
{
    public class ErrDetail
    {
        public string subject { get; set; }
        public string body { get; set; }
    }

    public static class ErrorMessage
    {
        public static void Send(EmailMessage email, Exception err = null)
        {
            var current = HttpContext.Current;

            if (err == null)
            {
                err = current.Server.GetLastError();
            }

            var detail = ErrDetails(err);

            email.Body = detail.body;
            email.Subject = detail.subject;
            email.Send("Error");
        }

        public static ErrDetail ErrDetails(Exception err)
        {
            HttpRequest req;
            string source;

            try
            {
                req = HttpContext.Current.Request;
                source = req.Url.Host;
            }
            catch
            {
                req = null;
                source = Settings.MainHost;
            }

            var subject = "";
            var body = "";

            try
            {
                subject = "Application Error in " + source;
                body = subject;

                if (req != null)
                {
                    body += "\r\n\r\nError in Path: " + req.Path;
                    body += "\r\nError Raw Url: " + req.RawUrl;
                    body += "\r\nError Absolute Url: " + req.Url.AbsoluteUri;
                    body += "\r\nUserAgent: " + req.UserAgent;
                    body += "\r\nUserHostAddress: " + req.UserHostAddress; ;
                    body += "\r\nReferal: " + ((req.UrlReferrer != null) ? req.UrlReferrer.AbsoluteUri : "");
                }

                body += "\r\n\r\nError Message: " + err.Message;
                body += "\r\n\r\n" + err.StackTrace;

                if (err.InnerException != null)
                {
                    body += "\r\n\r\nInner Exception: " + err.InnerException.Message;
                    body += "\r\n\r\n" + err.InnerException.StackTrace;
                }
            }
            catch (Exception newErr)
            {
                subject = "Complex Error in " + source;
                body = subject;
                body += "\r\n\r\nError 1 Message: " + err.Message;
                body += "\r\n\r\n" + err.StackTrace;
                body += "\r\n\r\nError 2 Message: " + newErr.Message;
                body += "\r\n\r\n" + newErr.StackTrace;
            }

            return new ErrDetail()
            {
                subject = subject,
                body = body
            };
        }
    }
}