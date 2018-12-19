using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shakelx.EFSimple.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shakelx.EFSimple.Infrastructure.DataBase.EntityConfigurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Price).HasColumnType("decimal(8,2)");
        }
    }
}
