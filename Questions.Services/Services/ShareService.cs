using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using Questions.Services.Interfaces;

namespace Questions.Services.Services
{
    public class ShareService : IShareService
    {
        public async Task ShareAsync(string destinationEmail, string contentUrl)
        {
            const string host = "smtp.ethereal.email";
            const string sender = "fabiola.vandervort@ethereal.email";
            const string password = "wfVhrmy8qv4t65z6qt";
            
            // create email message
            var email = new MimeMessage
            {
                Sender = MailboxAddress.Parse(sender)
            };
            email.To.Add(MailboxAddress.Parse(destinationEmail));
            email.Subject = "Share";
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = contentUrl
            };

            // send email
            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(host, 587, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(sender, password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}