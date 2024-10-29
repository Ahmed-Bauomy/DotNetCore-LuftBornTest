using ProductSystem.Application.Models;
using ProductSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Application.Adapters
{
    public interface IProductRepositoryAdapter : IAsyncRepositoryAdapter<Product>
    {
        Task<IEnumerable<ProductDTO>> GetProductsByCategory(string categoryName);
    }
}
