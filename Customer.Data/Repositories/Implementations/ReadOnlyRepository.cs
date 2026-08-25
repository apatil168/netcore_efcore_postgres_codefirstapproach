using Customer.Common.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Customer.Data.Repositories
{
    public class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> 
        where TEntity : BaseEntity
    {
        protected DbContext Context { get; private set; }

        public ReadOnlyRepository(DbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression)
        {
            var set = Set();
            // TODO : Add IIncludableQueryable function to add dynamic condition.
            //if (include != null)
            //    set = include(set);

            return set.Where(expression);
        }

        public async Task<TEntity?> GetById(int id)
        {
            var set = Set();
            //if (include != null)
            //    set = include(set);
            return await set.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
        }

        IQueryable<TEntity> Set()
            => Context.Set<TEntity>();
    }
}
