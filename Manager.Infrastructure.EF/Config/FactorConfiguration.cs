using Manager.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Infrastructure.EF.Config
{
    public class FactorConfiguration : IEntityTypeConfiguration<Factor>
    {
        public void Configure(EntityTypeBuilder<Factor> builder)
        {
            builder.HasKey(a => a.FactorId);
            builder.Property(a => a.Costomer).HasColumnType("NVARCHAR(50)").IsRequired();
            builder.Property(a => a.SellTime).HasColumnType("DateTime").IsRequired();
            builder.Property(a => a.Tedad).HasColumnType("INT").IsRequired();
            builder.HasMany(a => a.products);
            builder.HasMany(a => a.factor_Stores);
        }
    }
}
