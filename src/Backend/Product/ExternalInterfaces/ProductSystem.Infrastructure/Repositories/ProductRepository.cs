using Microsoft.EntityFrameworkCore;
using ProductSystem.Domain.Contracts;
using ProductSystem.Domain.Entities;
using ProductSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ProductContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(string categoryName)
        {
            return await GetAsync(p => p.Category ==  categoryName);
        }
    }
}
