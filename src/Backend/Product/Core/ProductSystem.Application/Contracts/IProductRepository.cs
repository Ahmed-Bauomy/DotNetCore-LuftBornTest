using ProductSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Domain.Contracts
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategory(string categoryName);
    }
}
