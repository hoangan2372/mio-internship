using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mio1412.Models;

namespace mio1412.EntityConfiguration
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.ToTable("Report");
            builder.Property(r => r.Task_Name)
                .IsRequired(true);
            builder.HasData
            (
                new Report
                {
                    Id = 1,
                    Task_Name = "task 1",
                    Issues = "",
                    Progress = "",
                }
                
            );

        }

    }
}
