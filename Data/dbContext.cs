using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mio1412.EntityConfiguration;
using mio1412.Models;

namespace mio1412.Data
{
    public class dbContext : DbContext
    {
        public dbContext (DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public DbSet<mio1412.Models.Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ReportConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
        }

        public DbSet<mio1412.Models.Report> Report { get; set; }

        public DbSet<mio1412.Models.Account> Account { get; set; }

    }
}
