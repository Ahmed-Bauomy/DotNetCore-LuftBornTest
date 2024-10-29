using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Application.Exceptions
{
    public class CustomValidationException : Exception
    {
        private List<string> Errors { get; }
        public CustomValidationException():base("one or more validation failures have occurred.") 
        { }

        public CustomValidationException(IEnumerable<ValidationFailure> failures)
        {
            Errors = failures.Select(x => x.PropertyName + ": " + x.ErrorMessage).ToList();
        }

        public override string ToString()
        {
            var error = Message + "\n";
            error += string.Join("\n", Errors);
            error += "\n" + base.ToString();
            return error;
        }
    }
}
