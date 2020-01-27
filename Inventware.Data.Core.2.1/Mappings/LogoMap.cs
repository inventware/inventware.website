using IAS.Data.Core2.Extensions;
using Inventware.Domain.Core2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace Inventware.Data.Core2.Mappings
{
    public class LogoMap : EntityTypeConfiguration<Logo, Guid>, IEntityTypeConfiguration<Logo>
    {
        public void Configure(EntityTypeBuilder<Logo> builder)
        {
            // Table Name
            builder.ToTable("Logos");

            // Primary Key
            builder.HasKey(field => field.Id);

            //builder.Property(field => field.ImagePath)
            //    .HasColumnType("varchar(1024)")
            //    .HasMaxLength(1024)
            //    .IsRequired();

            builder.Property(field => field.IsActive)
                .IsRequired();

            builder.HasOne(de => de.Customer)                 // Dependent Entity
                   .WithMany(pe => pe.Logos)                  // Principal Entity
                   .HasForeignKey(de => de.CustomerId)        // Dependent Entity
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            base.ConfigureBasicFields(builder);
        }
    }
}
