using Microsoft.EntityFrameworkCore;
using ProductSystem.Domain.Common;
using ProductSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Infrastructure.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options):base(options) 
        {
            Database.Migrate();
        }

        public virtual DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                        .Property(p => p.Price)
                        .HasColumnType("decimal(18,4)");
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
