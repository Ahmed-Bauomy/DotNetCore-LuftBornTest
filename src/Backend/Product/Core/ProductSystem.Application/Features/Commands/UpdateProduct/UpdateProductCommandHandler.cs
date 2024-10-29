using MediatR;
using ProductSystem.Application.Adapters;
using ProductSystem.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductSystem.Application.Features.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand,bool>
    {
        private readonly IProductRepositoryAdapter _productRepository;

        public UpdateProductCommandHandler(IProductRepositoryAdapter productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productTobeUpdated = await _productRepository.GetByIdAsync(request.Id);
            if (productTobeUpdated == null) 
            {
                throw new NotFoundException(request.Name,request.Id.ToString());
            }
            await _productRepository.UpdateAsync(request,productTobeUpdated);
            return true;
        }
    }
}
