using MediatR;
using ProductSystem.Application.Adapters;
using ProductSystem.Application.Contracts;
using ProductSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductSystem.Application.Features.Queries.GetProductsByCategory
{
    public class GetProductsByCategoryQueryHandler : IRequestHandler<GetProductsByCategoryQuery, List<ProductDTO>>
    {
        private readonly IProductRepositoryAdapter _productRepository;

        public GetProductsByCategoryQueryHandler(IProductRepositoryAdapter productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<ProductDTO>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductsByCategory(request.Category);
            return products.ToList();
        }
    }
}
