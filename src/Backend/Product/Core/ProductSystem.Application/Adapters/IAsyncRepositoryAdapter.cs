using ProductSystem.Application.Features.Commands.CreateProduct;
using ProductSystem.Application.Features.Commands.UpdateProduct;
using ProductSystem.Domain.Contracts;
using ProductSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Application.Adapters
{
    public interface IAsyncRepositoryAdapter<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                        string includeString = null,
                                        bool disableTracking = true);

        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(CreateProductCommand entity);
        Task UpdateAsync(UpdateProductCommand entity, Product entityToBeUpdated);
        Task DeleteAsync(T entity);
    }
}
