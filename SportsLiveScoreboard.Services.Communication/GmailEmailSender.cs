using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace SportsLiveScoreboard.Services.Communication
{
    public class GmailEmailSender : IEmailSender
    {
        private readonly IConfiguration _config;

        public GmailEmailSender(IConfiguration config)
        {
            _config = config;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            string name = _config.GetValue<string>("EmailCredentials:Name");
            string senderEmail = _config.GetValue<string>("EmailCredentials:Email");
            string password = _config.GetValue<string>("EmailCredentials:Password");
            return Task.Run(() =>
            {
                var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress(name, senderEmail));
                emailMessage.To.Add(new MailboxAddress("", email));
                emailMessage.Subject = subject;
                var bodyBuilder = new BodyBuilder
                {
                    HtmlBody = htmlMessage
                };
                emailMessage.Body = bodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    // Note: since we don't have an OAuth2 token, disable 	
                    // the XOAUTH2 authentication mechanism.
                    client.Authenticate(senderEmail, password);
                    client.Send(emailMessage);
                    client.Disconnect(true);
                }
            });
        }
    }
}