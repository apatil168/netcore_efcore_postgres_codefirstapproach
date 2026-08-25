using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Customer.Data
{
    public static class Startup
    {
        public static IServiceCollection AddCustomerDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            services.AddDbContext<CustomerDbContext>(options =>
                options.UseLazyLoadingProxies()
                .UseNpgsql(configuration.GetConnectionString("DbConnection"))
                .UseSnakeCaseNamingConvention());
            services.AddScoped<UnitOfWork.IUnitOfWork, UnitOfWork.UnitOfWork>();
            return services;
        }
    }
}
