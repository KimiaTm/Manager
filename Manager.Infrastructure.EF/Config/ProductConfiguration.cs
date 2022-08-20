using Manager.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Infrastructure.EF.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
           builder.HasKey(a=>a.ProductId);
            builder.Property(a => a.ProductName).HasColumnType("NVARCHAR(50)").IsRequired();
            builder.Property(a => a.Brand).HasColumnType("NVARCHAR(50)").IsRequired();
            builder.Property(a => a.Quantity).HasColumnType("NVARCHAR(50)").IsRequired();
            builder.Property(a => a.Price).HasColumnType("int").IsRequired();
            builder.HasOne(a => a.Store).WithMany().HasForeignKey(a=>a.StoreId);
            builder.HasOne(a => a.factor).WithMany().HasForeignKey(a=>a.FactorId);
            
       
        }
    }
}
