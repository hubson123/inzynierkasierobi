using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PersonalniePL.Models
{
    public class Mail
    {
        public static void SendMail(string subject, string body)
        {
            var message = new System.Net.Mail.MailMessage(ConfigurationManager.AppSettings["sender"], "hubert.firek@o2.pl")
            {
                Subject = subject,
                Body = body
            };

            var smtpClient = new System.Net.Mail.SmtpClient
            {
                Host = ConfigurationManager.AppSettings["smtp"],
                Credentials = new System.Net.NetworkCredential(
           ConfigurationManager.AppSettings["sender"],
           ConfigurationManager.AppSettings["passwd"]),
                EnableSsl = true
            };
            smtpClient.Send(message);
        }
    }
}