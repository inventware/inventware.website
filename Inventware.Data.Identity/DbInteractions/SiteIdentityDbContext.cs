using IAS.CrossCutting.Core.Entities;
using Inventware.Data.Identity.Mappings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Inventware.Data.Identity.DbInteractions
{
    /// <summary>
    /// https://docs.microsoft.com/pt-br/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-2.2
    /// </summary>
    public class SiteIdentityDbContext
        : IdentityDbContext<
            ApplicationUser,
            ApplicationRole,
            Guid,
            ApplicationUserClaim,
            ApplicationUserRole,
            ApplicationUserLogin,
            ApplicationRoleClaim,
            ApplicationUserToken>
    {
        public SiteIdentityDbContext() { }

        public SiteIdentityDbContext(DbContextOptions<SiteIdentityDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações do Mapeamento das Entidades.
            modelBuilder
                .ApplyConfiguration(new ApplicationRoleMap())
                .ApplyConfiguration(new ApplicationUserMap())
                .ApplyConfiguration(new ApplicationUserClaimMap());

            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Get the configuration from the app settings
                var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string applicationExeDirectory = Path.GetDirectoryName(location);

                var builder = new ConfigurationBuilder()
                    .SetBasePath(applicationExeDirectory)
                    .AddJsonFile("appsettings.json");
                IConfigurationRoot configurationRoot = builder.Build();
                var connectionString = configurationRoot.GetConnectionString("IFCConnection");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
