using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using WebMVCComDDD.Application.Helpers;
using WebMVCComDDD.Application.Interfaces;

namespace WebMVCComDDD.Application.Applications
{
    public class EmailApplication : IEmailApplication
    {
        private readonly EmailSettings _mailSettings;

        public EmailApplication(IOptions<EmailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(EmailRequest mailRequest)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            message.From = new MailAddress(_mailSettings.Mail, _mailSettings.DisplayName);
            message.To.Add(new MailAddress(mailRequest.ToEmail));
            message.Subject = mailRequest.Subject;

            if (mailRequest.Attachments != null)
            {
                foreach (var file in mailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            var fileBytes = ms.ToArray();
                            Attachment att = new Attachment(new MemoryStream(fileBytes), file.FileName);
                            message.Attachments.Add(att);
                        }
                    }
                }
            }

            message.IsBodyHtml = true;

            message.Body = mailRequest.Body;
            smtp.Port = _mailSettings.Port;
            smtp.Host = _mailSettings.Host;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(message);
        }
    }
}