using System;
using System.IO;
using Inventware.Data.Core2.Mappings;
using Inventware.Domain.Core2.Entities;
using Microsoft.EntityFrameworkCore;


namespace Inventware.Data.Core2.DbInteractions
{
    public class SiteDbContext : DbContext
    {
        public DbSet<Banner> BANNER { get; set; }

        public DbSet<Customer> CUSTOMER { get; set; }

        public DbSet<CustomerCase> CUSTOMER_CASE { get; set; }

        public DbSet<Image> IMAGE { get; set; }

        public DbSet<Logo> LOGO { get; set; }

        public DbSet<TextBlock> TEXT_BLOCK { get; set; }


        public SiteDbContext() { }

        public SiteDbContext(DbContextOptions<SiteDbContext> options)
            : base(options)
        { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   
            // Esta opção tem que vir no parâmetro optionBuilder.
            //optionsBuilder.UseSqlServer("Server=DESKTOP-A139M27\\SQLEXPRESS;Database=InventwareSite;User ID=sa;Password=_cfc5269;Trusted_Connection=True;MultipleActiveResultSets=true");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply all configurations
            modelBuilder
                .ApplyConfiguration(new BannerMap())
                .ApplyConfiguration(new CustomerMap())
                .ApplyConfiguration(new CustomerCaseMap())
                .ApplyConfiguration(new ImageMap())
                .ApplyConfiguration(new LogoMap())
                .ApplyConfiguration(new TextBlockMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
