using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mio1412.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mio1412.EntityConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.Property(p => p.Name)
                .IsRequired(false);
            builder.HasData
            (
                new Product
                {
                    Id = 1,
                    Name = "Product A",
                    Price = 200
                },
                new Product
                {
                    Id = 2,
                    Name = "Product B",
                    Price = 250
                }
            );
        }
    }

}
