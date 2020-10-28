using Fanfic.Configuration;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading.Tasks;

namespace Fanfic.Services
{
    public class EmailSenderService
    {
        public async Task SendEmailAsync(string email, string subject, string message, IOptions<EmailConfig> option)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Fanfic administration", option.Value.Email));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
               
                await client.ConnectAsync("smtp.mail.ru", 587, MailKit.Security.SecureSocketOptions.Auto);
                await client.AuthenticateAsync(option.Value.Email, option.Value.Password);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }

        }
    }
}
