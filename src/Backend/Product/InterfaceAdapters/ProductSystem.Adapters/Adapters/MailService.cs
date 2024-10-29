using ProductSystem.Adapters.Contracts;
using ProductSystem.Application.Contracts;
using ProductSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Adapters.Adapters
{
    public class MailService : IMailService
    {
        private readonly IMailServiceAdapter _mailServiceAdapter;

        public MailService(IMailServiceAdapter mailServiceAdapter)
        {
            _mailServiceAdapter = mailServiceAdapter;
        }

        public Task<bool> SendEmail(string id)
        {
            var email = new Email()
            {
                To = "mail@test.com",
                Subject = "New Product Created",
                Body = $" Product Created with Id = {id}"
            };
            return _mailServiceAdapter.SendEmail(email);
        }
    }
}
