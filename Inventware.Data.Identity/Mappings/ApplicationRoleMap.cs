using IAS.CrossCutting.Core.Entities;
using IAS.CrossCutting.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace Inventware.Data.Identity.Mappings
{
    public class ApplicationRoleMap : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder
                .ToTable("AspNetRoles");

            builder
                .Property(field => field.Name)
                .HasColumnType("varchar(30)")
                .HasMaxLength(30)
                .IsRequired();

            builder
                .HasData(
                    new ApplicationRole
                    {
                        Id = Guid.Parse("0581a79e-6e0a-448d-be5a-d398813edaa4"),
                        Name = "Data Addition",
                        EClaimValue = EClaimValue.Add
                    },
                    new ApplicationRole
                    {
                        Id = Guid.Parse("072443c3-9008-42e6-b274-a703bd7defdd"),
                        Name = "Data Change",
                        EClaimValue = EClaimValue.Change
                    },
                    new ApplicationRole
                    {
                        Id = Guid.Parse("bfcc116f-25e8-4022-8dc6-30a2a26b2f4a"),
                        Name = "System Configuration",
                        EClaimValue = EClaimValue.Configure
                    },
                    new ApplicationRole
                    {
                        Id = Guid.Parse("98f1716a-7ef7-42bc-9058-943931becaa2"),
                        Name = "Read Access",
                        EClaimValue = EClaimValue.Read
                    },
                    new ApplicationRole
                    {
                        Id = Guid.Parse("12827f07-86f8-40b3-8ee9-5cc05838dcae"),
                        Name = "Data Remotion",
                        EClaimValue = EClaimValue.Remove
                    }
                );
        }
    }
}
