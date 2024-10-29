using ProductSystem.Adapters.Contracts;
using ProductSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ProductSystem.Infrastructure.Mail
{
    public class InFraMailService : IMailServiceAdapter
    {
        public async Task<bool> SendEmail(Email email)
        {
            var from = new EmailAddress()
            {
                Email = "FromAddress",
                Name = "FromName"
            };
            var to = new EmailAddress(email.To);
            var subject = email.Subject;
            var emailBody = email.Body;

            var emailMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
            var client = new SendGridClient("ApiKey");
            var response = await client.SendEmailAsync(emailMessage);
            if (response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
    }
}
