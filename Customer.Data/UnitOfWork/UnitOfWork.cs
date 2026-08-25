using Customer.Common.Entities;
using Customer.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Customer.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected CustomerDbContext Context { get; private set; }
        public UnitOfWork(CustomerDbContext context)
        { 
          Context = context;
        }

        public async Task CommitAsync()
        {
            foreach (var entry in Context.ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                UnitOfWork.AuditableCommitHook(entry);
            }

            await Context.SaveChangesAsync();
        }

        protected static void AuditableCommitHook(EntityEntry entry)
        {
            if (entry.Entity is not BaseEntity entity) return;

            entity.UpdatedTimestamp = DateTime.UtcNow;

            if (entry.State == EntityState.Added)
            {
                entity.CreatedTimestamp = DateTime.UtcNow;
            }
        }

        public IRepository<Entities.Customer> CustomerRepository => new Repository<Entities.Customer>(Context);
    }
}
