using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;

namespace WebAppTemplate.Helpers
{   public static class EmailHelpers
    {
        public static SmtpClient GetSmtpClient()
        {
            SmtpClient smtpClient = new SmtpClient(EmailServiceCredentials.EmailSMTPUrl);
            smtpClient.Port = (EmailServiceCredentials.PortNumber);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(
                EmailServiceCredentials.EmailSMTPUserNameHash,
                EmailServiceCredentials.EmailSMTPPasswordHash
            );

            return smtpClient;
        }

        public static MailMessage GenerateMailMessage(string destination, string subject, string body)
        {
            MailMessage mailMessage = new MailMessage(
                new MailAddress(EmailServiceCredentials.EmailFromAddress, EmailServiceCredentials.EmailFromName),
                new MailAddress(destination)
            );
            mailMessage.Subject = EmailServiceCredentials.EmailAppName + " - " + subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;

            return mailMessage;
        }
    }
}