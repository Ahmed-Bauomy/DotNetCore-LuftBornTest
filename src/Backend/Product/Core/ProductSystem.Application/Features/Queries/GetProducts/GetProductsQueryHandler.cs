using MediatR;
using ProductSystem.Application.Adapters;
using ProductSystem.Application.Features.Queries.GetProductsByCategory;
using ProductSystem.Application.Models;
using ProductSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductSystem.Application.Features.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDTO>>
    {
        private readonly IProductRepositoryAdapter _productRepository;

        public GetProductsQueryHandler(IProductRepositoryAdapter productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<ProductDTO>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();
            return products.ToList();
        }
    }
}
