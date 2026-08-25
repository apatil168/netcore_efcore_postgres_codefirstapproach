using Customer.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customer.Common.EntityConfigurations
{
    public abstract class BaseEntityConfiguration<TBaseEntity> : IEntityTypeConfiguration<TBaseEntity> where TBaseEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TBaseEntity> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.CreatedTimestamp)
                .HasColumnType("timestamp")
                .HasDefaultValueSql("NOW()")
                .IsRequired();
            builder.Property(b => b.UpdatedTimestamp)
                .HasColumnType("timestamp")
                .HasDefaultValueSql("NOW()")
                .IsRequired();
        }
    }
}
