using System;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace SchooledAPI.Utilities
{
    public class EmailMessage
    {
        public string Body { get; set; }
        public string Subject { get; set; }
        public string FromAddress { get; set; }
        public string ReplyTo { get; set; }
        public string FromName { get; set; }
        public string[] ToAddresses { get; set; }
        public string[] CCAddresses { get; set; }
        public string[] BCCAddresses { get; set; }
        public bool HTML { get; set; }
        public string Server { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? Port { get; set; }
        public bool SSL { get; set; }
        public Stream Attachment { get; set; }
        public string AttachmentMimeType { get; set; }
        public string AttachmentName { get; set; }

        public void Send(string messageType)
        {
            if (
                string.IsNullOrEmpty(Body) ||
                string.IsNullOrEmpty(Subject) ||
                string.IsNullOrEmpty(FromAddress) ||
                string.IsNullOrEmpty(Server) ||
                (ToAddresses == null) ||
                (ToAddresses != null && ToAddresses.Length == 0)
                )
            {
                throw new Exception("Email object missing required properties");
            }

            var mail = new MailMessage();

            mail.Headers.Add("X-xsMailingId", Settings.MainHost.ToFriendly());
            mail.Headers.Add("X-xsMessageId", messageType.ToFriendly());
            mail.From = new MailAddress(FromAddress, (string.IsNullOrEmpty(FromName)) ? FromAddress : FromName);
            mail.ReplyToList.Add((!string.IsNullOrEmpty(ReplyTo)) ? ReplyTo : FromAddress);
            mail.Subject = Subject;
            mail.Body = Body;
            mail.IsBodyHtml = HTML;

            foreach (var e in ToAddresses)
            {
                mail.To.Add(e);
            }

            if (CCAddresses != null)
            {
                foreach (var e in CCAddresses)
                {
                    mail.CC.Add(e);
                }
            }

            if (BCCAddresses != null)
            {
                foreach (var e in BCCAddresses)
                {
                    mail.Bcc.Add(e);
                }
            }

            if (Attachment != null)
            {
                mail.Attachments.Add(new Attachment(Attachment, AttachmentName, AttachmentMimeType));
            }

            var smtpServer = new SmtpClient(Server);
            if (Port != null) smtpServer.Port = (int)Port.Value;

            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            {
                smtpServer.Credentials = new NetworkCredential(Username, Password);
            }

            smtpServer.EnableSsl = SSL;
            smtpServer.Send(mail);

            if (Attachment != null)
            {
                Attachment.Dispose();
            }
        }
    }
}