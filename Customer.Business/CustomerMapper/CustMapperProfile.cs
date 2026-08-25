using AutoMapper;

namespace Customer.Business.CustomerMapper
{
    public class CustMapperProfile : Profile
    {
        public CustMapperProfile()
        {
            CreateMap<Data.Entities.Customer, Dto.Customer>().ReverseMap();
        }
    }
}
