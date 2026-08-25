using Customer.Common.EntityConfigurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customer.Data.EntityConfigurations
{
    public class CustomerEntityConfiguration : BaseEntityConfiguration<Entities.Customer>
    {
        public override void Configure(EntityTypeBuilder<Entities.Customer> builder)
        {
            builder.Property(x => x.Email).HasMaxLength(256);
            builder.Property(x => x.FirstName).HasMaxLength(500).IsRequired();
            base.Configure(builder);
        }
    }
}
