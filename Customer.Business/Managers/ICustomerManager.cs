using Customer.Business.Dto;

namespace Customer.Business.Managers
{
    public interface ICustomerManager
    {
        Task<Dto.Customer> GetById(int id);
        Task<List<Dto.Customer>> GetAll();
        Task<int> Save(Dto.Customer dto);
        Task<Dto.Customer> Update(int userId, Dto.Customer dto);
        Task Delete(int id);
    }
}
