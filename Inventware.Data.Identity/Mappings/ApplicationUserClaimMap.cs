using IAS.CrossCutting.Core.Entities;
using IAS.CrossCutting.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace Inventware.Data.Identity.Mappings
{
    public class ApplicationUserClaimMap : IEntityTypeConfiguration<ApplicationUserClaim>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserClaim> builder)
        {
            builder
                .ToTable("AspNetUserClaims");

            builder
                .Property(field => field.ClaimType)
                .IsRequired();

            builder
                .Property(field => field.ClaimValue)
                .IsRequired();

            builder
                .HasData(
                    new ApplicationUserClaim
                    {
                        Id = 1,
                        UserId = Guid.Parse("AF943E01-772B-456B-6C23-08D79857354A"),
                        ClaimType = EClaimType.Cadasters.ToString(),
                        ClaimValue = EClaimValue.Read.ToString() + "," + EClaimValue.Add.ToString() + "," +
                            EClaimValue.Change.ToString() + "," + EClaimValue.Remove.ToString()
                    },
                    new ApplicationUserClaim
                    {
                        Id = 2,
                        UserId = Guid.Parse("AF943E01-772B-456B-6C23-08D79857354A"),
                        ClaimType = EClaimType.Queries.ToString(),
                        ClaimValue = EClaimValue.Read.ToString() + "," + EClaimValue.Configure.ToString()
                    },
                    new ApplicationUserClaim
                    {
                        Id = 3,
                        UserId = Guid.Parse("AF943E01-772B-456B-6C23-08D79857354A"),
                        ClaimType = EClaimType.Reports.ToString(),
                        ClaimValue = EClaimValue.Read.ToString() + "," + EClaimValue.Configure.ToString()
                    },
                    new ApplicationUserClaim
                    {
                        Id = 4,
                        UserId = Guid.Parse("AF943E01-772B-456B-6C23-08D79857354A"),
                        ClaimType = EClaimType.UserAdministration.ToString(),
                        ClaimValue = EClaimValue.Configure.ToString()
                    },
                    new ApplicationUserClaim
                    {
                        Id = 5,
                        UserId = Guid.Parse("AF943E01-772B-456B-6C23-08D79857354A"),
                        ClaimType = EClaimType.SystemAdministration.ToString(),
                        ClaimValue = EClaimValue.Configure.ToString()
                    }
                );
        }
    }
}
