using Customer.Business.Dto;
using Customer.Data.UnitOfWork;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Customer.Business.Managers
{
    public class CustomerManager : ICustomerManager
    {
        readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;

        public CustomerManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Dto.Customer>> GetAll()
        {
            return _mapper.Map<List< Dto.Customer>> (await _unitOfWork.CustomerRepository.GetAll(a => true).OrderBy(x => x.Id).ToListAsync());
        }

        public async Task<Dto.Customer> GetById(int id)
        {
            return _mapper.Map<Dto.Customer>(await _unitOfWork.CustomerRepository.GetById(id));
        }

        public async Task<int> Save(Customer.Business.Dto.Customer dto)
        {
            var entity = dto.Id > 0 ? _mapper.Map(dto, await _unitOfWork.CustomerRepository.GetById(dto.Id)) : _mapper.Map<Data.Entities.Customer>(dto);
            if (entity == null)
                throw new ArgumentNullException("Cannot insert null entity", nameof(entity));
            _unitOfWork.CustomerRepository.Save(entity);
            await _unitOfWork.CommitAsync();
            return entity.Id;
        }

        public async Task<Dto.Customer> Update(int userId, Dto.Customer dto)
        {
            if (userId <= 0)
                throw new ArgumentNullException(nameof(userId));

            var dataCustomer = await GetById(userId);
            if (dataCustomer == null)
                throw new NullReferenceException($"User with user id: {userId} does not exist.");

            if (dataCustomer.Equals(dto))
                return dto;

            dataCustomer.Email = dto.Email;
            dataCustomer.FirstName = dto.FirstName;
            dataCustomer.LastName = dto.FirstName;

            await Save(dataCustomer);
            return dataCustomer;
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.CustomerRepository.Delete(id);
            await _unitOfWork.CommitAsync();

        }
    }
}
