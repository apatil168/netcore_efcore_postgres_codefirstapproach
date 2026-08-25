using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Customer.Data
{
    public class CustomerDbContextFactory : IDesignTimeDbContextFactory<CustomerDbContext>
    {
        public CustomerDbContext CreateDbContext(string[] args)
        {
            var buidler = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            var config = buidler.Build();

            var optionBuilder = new DbContextOptionsBuilder<CustomerDbContext>();
            optionBuilder
                .UseNpgsql(config.GetConnectionString("DbConnection"))
                .UseSnakeCaseNamingConvention();
            return new CustomerDbContext(optionBuilder.Options);
        }

    }
}
