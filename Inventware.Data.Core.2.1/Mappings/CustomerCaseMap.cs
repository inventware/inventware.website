using IAS.Data.Core2.Extensions;
using Inventware.Domain.Core2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace Inventware.Data.Core2.Mappings
{
    public class CustomerCaseMap : EntityTypeConfiguration<CustomerCase, Guid>, IEntityTypeConfiguration<CustomerCase>
    {
        public void Configure(EntityTypeBuilder<CustomerCase> builder)
        {
            builder.ToTable("CustomerCases");

            builder.HasKey(field => field.Id);

            builder.Property(field => field.Title)
                .HasColumnType("varchar(128)")
                .HasMaxLength(128)
                .IsRequired();

            builder.HasOne(de => de.Customer)                 // Dependent Entity
                   .WithMany(pe => pe.CustomerCases)          // Principal Entity
                   .HasForeignKey(de => de.CustomerId)        // Dependent Entity
                   .IsRequired();

            base.ConfigureBasicFields(builder);
        }
    }
}
