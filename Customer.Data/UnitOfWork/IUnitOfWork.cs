using Customer.Data.Repositories;
using Customer.Data;

namespace Customer.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CommitAsync();

        IRepository<Entities.Customer> CustomerRepository { get; }
    }
}
