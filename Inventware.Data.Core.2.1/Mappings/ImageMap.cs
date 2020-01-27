using IAS.Data.Core2.Extensions;
using Inventware.Domain.Core2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace Inventware.Data.Core2.Mappings
{
    public class ImageMap : EntityTypeConfiguration<Image, Guid>, IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            // Table Name
            builder.ToTable("Images");

            // Primary Key
            builder.HasKey(field => field.Id);

            builder.Property(field => field.Title)
                .HasColumnType("varchar(128)")
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(field => field.Path)
                .HasColumnType("varchar(1024)")
                .HasMaxLength(1024)
                .IsRequired();

            builder.Property(field => field.ImageType)
                .HasColumnType("int")
                .IsRequired();

            base.ConfigureBasicFields(builder);
        }
    }
}
