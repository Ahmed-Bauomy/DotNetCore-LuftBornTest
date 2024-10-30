using AutoMapper;
using MediatR;
using ProductSystem.Application.Adapters;
using ProductSystem.Application.Features.Commands.CreateProduct;
using ProductSystem.Application.Features.Commands.UpdateProduct;
using ProductSystem.Application.Models;
using ProductSystem.Domain.Contracts;
using ProductSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Adapters.Adapters
{
    public class ProductRepositoryAdapter : IProductRepositoryAdapter
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductRepositoryAdapter(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Product> AddAsync(CreateProductCommand entity)
        {
            var product = _mapper.Map<Product>(entity);
            return await _repository.AddAsync(product);
        }

        public async Task DeleteAsync(Product entity)
        {
            await _repository.DeleteAsync(entity);
        }

        public async Task<IReadOnlyList<ProductDTO>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public async Task<IReadOnlyList<Product>> GetAsync(Expression<Func<Product, bool>> predicate)
        {
            return await _repository.GetAsync(predicate);
        }

        public async Task<IReadOnlyList<Product>> GetAsync(Expression<Func<Product, bool>> predicate = null, Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null, string includeString = null, bool disableTracking = true)
        {
            return await _repository.GetAsync(predicate, orderBy, includeString, disableTracking);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsByCategory(string categoryName)
        {
            var products = await _repository.GetProductsByCategory(categoryName);
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public async Task UpdateAsync(UpdateProductCommand entity,Product entityToBeUpdated)
        {
            _mapper.Map(entity,entityToBeUpdated,typeof(UpdateProductCommand),typeof(Product));
            await _repository.UpdateAsync(entityToBeUpdated);
        }
    }
}
