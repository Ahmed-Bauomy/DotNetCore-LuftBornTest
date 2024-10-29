using Microsoft.EntityFrameworkCore;
using ProductSystem.Domain.Common;
using ProductSystem.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : EntityBase
    {
        private readonly DbContext dbContext;
        private readonly DbSet<T> dbSet;

        public RepositoryBase(DbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            dbSet.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disableTracking = true)
        {
            var query = dbSet.AsQueryable();
            if (!string.IsNullOrEmpty(includeString)) query = query.Include(includeString);
            if(predicate != null) query = query.Where(predicate);
            if (disableTracking) query = query.AsNoTracking();
            if (orderBy != null) return await orderBy(query).ToListAsync();

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            dbSet.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
