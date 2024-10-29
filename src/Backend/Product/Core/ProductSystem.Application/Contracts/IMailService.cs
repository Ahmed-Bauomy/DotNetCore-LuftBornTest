using ProductSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Application.Contracts
{
    public interface IMailService
    {
        Task<bool> SendEmail(string id);
    }
}
