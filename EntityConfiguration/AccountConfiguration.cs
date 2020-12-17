using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mio1412.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mio1412.EntityConfiguration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");
            builder.Property(a => a.DateCreated)
                .IsRequired(false);
            builder.Property(a => a.Username)
                .IsRequired(true);
            builder.Property(a => a.Password)
                .IsRequired(true);
            builder.HasData
            (
                new Account
                {
                    Id = 1,
                    Name = "Hoàng An",
                    Username = "hoangan",
                    Password = "123",
                    DateCreated = DateTime.Now
                }
                
            );
        }
    }

}
