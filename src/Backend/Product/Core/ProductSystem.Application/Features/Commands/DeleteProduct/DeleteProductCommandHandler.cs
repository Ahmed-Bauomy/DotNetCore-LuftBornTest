using MediatR;
using ProductSystem.Application.Adapters;
using ProductSystem.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductSystem.Application.Features.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepositoryAdapter _productRepository;

        public DeleteProductCommandHandler(IProductRepositoryAdapter productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productTobeDeleted = await _productRepository.GetByIdAsync(request.Id);
            if (productTobeDeleted == null)
            {
                throw new NotFoundException("", request.Id.ToString());
            }
            await _productRepository.DeleteAsync(productTobeDeleted);
            return true;
        }
    }
}
