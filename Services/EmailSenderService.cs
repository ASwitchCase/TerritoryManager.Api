using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using TerritoryManager.Api.Settings;

namespace EmailSender.api.Services
{
    public class EmailSenderService : IEmailSender
    {
        private readonly string user;
        private readonly string password;
        public EmailSenderService(EmailSettings settings){
            user = settings.GetUserEmail();
            password = settings.GetEmailPassword();
        }
        public Task SendEmailAsync(string email, string subject, string message)
    {
        var client = new SmtpClient("smtp.gmail.com", 587)
        {
            EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(user, password)
        };
 
        return client.SendMailAsync(
            new MailMessage(from: user,
                            to: email,
                            subject,
                            message
                            ));
    }
    }
}