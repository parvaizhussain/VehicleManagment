using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.IO;
using Microsoft.AspNetCore.Identity.UI.Services;
using Prj_CarPool.Extensions;
using System.Net;

namespace Prj_CarPool.IServices.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _mailSettings;
        public EmailSender(IOptions<EmailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public async Task SendEmailAsync(string emailTo, string subject, string htmlMessage)
        {
            try
            {

            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.EMail);
            email.To.Add(MailboxAddress.Parse(emailTo));
            email.Subject = subject;
            var builder = new BodyBuilder();
            
            builder.HtmlBody = htmlMessage;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
                System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.EMail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
    }
}

