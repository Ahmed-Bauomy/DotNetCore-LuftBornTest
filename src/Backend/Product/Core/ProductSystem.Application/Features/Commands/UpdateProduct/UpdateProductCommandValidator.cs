using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Application.Features.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Name} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{Name} length must not exceed 50 characters.");

            RuleFor(t => t.Price)
                .NotEmpty().WithMessage("{Price} is required")
                .GreaterThan(0).WithMessage("{Price} must be greater than Zero");
        }
    }
}
