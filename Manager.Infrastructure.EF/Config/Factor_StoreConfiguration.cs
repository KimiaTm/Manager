using Manager.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Infrastructure.EF.Config
{
    public class Factor_StoreConfiguration : IEntityTypeConfiguration<Factor_Store>
    {
        public void Configure(EntityTypeBuilder<Factor_Store> builder)
        {
            builder.HasKey(a => a.Factor_StoreId);
            builder.HasOne(a => a.Store);
            builder.HasOne(a => a.Factor);
        }
    }
}
