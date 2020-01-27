using IAS.Data.Core2.Extensions;
using Inventware.Domain.Core2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace Inventware.Data.Core2.Mappings
{
    //public class CustomerCaseTextBlocksMap : EntityTypeConfiguration<CustomerCaseTextBlock, Guid>, 
    //                                         IEntityTypeConfiguration<CustomerCaseTextBlock>
    //{
    //    public void Configure(EntityTypeBuilder<CustomerCaseTextBlock> builder)
    //    {
    //        builder.ToTable("CustomerCaseTextBlocks");

    //        builder.HasKey(field => field.Id);

    //        builder.HasOne(de => de.CustomerCase)                 // Dependent Entity
    //               .WithMany(pe => pe.CustomerCaseTextBlocks)     // Principal Entity
    //               .HasForeignKey(de => de.CustomerCaseId)        // Dependent Entity
    //               .IsRequired();

    //        builder.HasOne(de => de.TextBlock)                    // Dependent Entity
    //               .WithMany(pe => pe.CustomerCaseTextBlocks)     // Principal Entity
    //               .HasForeignKey(de => de.TextBlockId)           // Dependent Entity
    //               .IsRequired();

    //        base.ConfigureBasicFields(builder);
    //    }
    //}
}
