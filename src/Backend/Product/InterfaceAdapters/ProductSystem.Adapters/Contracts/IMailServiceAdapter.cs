using ProductSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Adapters.Contracts
{
    public interface IMailServiceAdapter
    {
        Task<bool> SendEmail(Email email);
    }
}
