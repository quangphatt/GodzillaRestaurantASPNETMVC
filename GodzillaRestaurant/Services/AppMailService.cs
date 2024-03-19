using GodzillaRestaurant.Models;
using MailKit.Security;
using MimeKit;

namespace GodzillaRestaurant.Services
{
    public class AppMailService : IMailService
    {
        const string MAIL_HOST = "smtp.gmail.com";
        const int MAIL_PORT = 587;

        public AppMailService() { }

        public async Task SendMail(MailContent mailContent)
        {
            // Use SmtpClient of MailKit
            using var smtp = new MailKit.Net.Smtp.SmtpClient();

            try
            {
                var emailAddress = Environment.GetEnvironmentVariable("EMAIL_ADDRESS");
                var emailPassword = Environment.GetEnvironmentVariable("EMAIL_PASSWORD");
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(emailAddress);
                email.To.Add(MailboxAddress.Parse(mailContent.To));
                email.Subject = mailContent.Subject;

                var builder = new BodyBuilder();
                builder.HtmlBody = mailContent.Body;
                email.Body = builder.ToMessageBody();

                // Send Mail
                smtp.Connect(MAIL_HOST, MAIL_PORT, SecureSocketOptions.StartTls);
                smtp.Authenticate(emailAddress, emailPassword);
                await smtp.SendAsync(email);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

            smtp.Disconnect(true);
        }
    }
}
