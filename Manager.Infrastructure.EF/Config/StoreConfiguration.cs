using Manager.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Infrastructure.EF.Config
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
           builder.HasKey(a=>a.Id);
            builder.Property(a => a.ProductName).HasColumnType("NVARCHAR(50)").IsRequired();
            builder.Property(a => a.Mojodi).HasColumnType("int").IsRequired();
            builder.HasMany(a => a.products);
            builder.HasMany(a => a.factor_Stores);
        }
    }
}
