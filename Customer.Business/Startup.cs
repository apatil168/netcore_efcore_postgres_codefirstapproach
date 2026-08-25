using Customer.Business.Managers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Customer.Data;
using AutoMapper;
using Customer.Business.CustomerMapper;

namespace Customer.Business
{
    public static class Startup
    {
        public static IServiceCollection AddInternalManagers(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICustomerManager, CustomerManager>();
            services.AddSingleton(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CustMapperProfile>();
            }).CreateMapper());
            services.AddCustomerDbContext(configuration);
            return services;
        }
    }
}
