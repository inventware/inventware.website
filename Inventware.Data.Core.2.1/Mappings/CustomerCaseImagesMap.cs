using IAS.Data.Core2.Extensions;
using Inventware.Domain.Core2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace Inventware.Data.Core2.Mappings
{
    public class CustomerCaseImagesMap : EntityTypeConfiguration<CustomerCase, Guid>, 
                                         IEntityTypeConfiguration<CustomerCase>
    {
        public void Configure(EntityTypeBuilder<CustomerCase> builder)
        {
            builder.ToTable("CustomerCaseImages");

            builder.HasKey(field => field.Id);

            //builder.HasOne(de => de.CustomerCase)                 // Dependent Entity
            //       .WithMany(pe => pe.CustomerCaseImages)         // Principal Entity
            //       .HasForeignKey(de => de.CustomerCaseId)        // Dependent Entity
            //       .IsRequired();

            //builder.HasOne(de => de.Image)                        // Dependent Entity
            //   .WithMany(pe => pe.CustomerCaseImages)             // Principal Entity
            //   .HasForeignKey(de => de.ImageId)                   // Dependent Entity
            //   .IsRequired();

            base.ConfigureBasicFields(builder);
        }
    }
}
