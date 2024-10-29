using FluentValidation;
using MediatR;
using ProductSystem.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductSystem.Application.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators ?? throw new ArgumentNullException(nameof(validators));
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var valiationContext = new ValidationContext<TRequest>(request);
                var validationResult = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(valiationContext)));
                var errors = validationResult.SelectMany(r => r.Errors).Where(r => r != null).ToList();
                if (errors.Any())
                {
                    throw new CustomValidationException(errors);
                }
            }
            return await next();
        }
    }
}
