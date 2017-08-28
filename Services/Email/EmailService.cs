using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using NXS.Services.Abstract;

namespace NXS.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _iconfiguration;
        private readonly string _credentialsUserName;
        private readonly string _credentialsPassword;
        private readonly string _emailTo;


        public EmailService(IConfiguration iconfiguration){
            _iconfiguration = iconfiguration;
            _credentialsUserName = _iconfiguration.GetValue<string>("SmtpClient:CredentialsUserName");
            _credentialsPassword = _iconfiguration.GetValue<string>("SmtpClient:CredentialsPassword");
            _emailTo = _iconfiguration.GetValue<string>("SmtpClient:EmailTo");
        }

        
        public async Task SendEmailAsync(string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("theresourcenexus@gmail.com", "theresourcenexus@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", _emailTo));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s,c,h,e) => true;
                await client.ConnectAsync("smtp.gmail.com", 587);
                await client.AuthenticateAsync(_credentialsUserName, _credentialsPassword);
                await client.SendAsync(emailMessage).ConfigureAwait(false);

                await client.DisconnectAsync(true);
            }

        }
    }
}