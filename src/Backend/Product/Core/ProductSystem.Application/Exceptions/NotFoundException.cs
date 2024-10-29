using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, string key)
            : base($"entity \"{name}\" with key {key} not found")
        {
            
        }
    }
}
