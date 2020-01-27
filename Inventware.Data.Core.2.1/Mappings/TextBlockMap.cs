using IAS.Data.Core2.Extensions;
using Inventware.Domain.Core2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Inventware.Data.Core2.Mappings
{
    public class TextBlockMap : EntityTypeConfiguration<TextBlock, Guid>, IEntityTypeConfiguration<TextBlock>
    {
        public void Configure(EntityTypeBuilder<TextBlock> builder)
        {
            // Table Name
            builder.ToTable("TextBlocks");

            // Primary Key
            builder.HasKey(field => field.Id);

            builder.Property(field => field.Name)
                .HasColumnType("varchar(120)")
                .HasMaxLength(120)
                .IsRequired();

            builder.Property(field => field.Content)
                .HasColumnType("varchar(2056)")
                .HasMaxLength(1024)
                .IsRequired();

            builder.Property(field => field.IsVisible)
                .IsRequired();

            base.ConfigureBasicFields(builder);
        }
    }
}
