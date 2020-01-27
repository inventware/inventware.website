using IAS.Data.Core2.Extensions;
using Inventware.Domain.Core2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace Inventware.Data.Core2.Mappings
{
    public class BannerMap : EntityTypeConfiguration<Banner, Guid>, IEntityTypeConfiguration<Banner>
    {
        public void Configure(EntityTypeBuilder<Banner> builder)
        {
            builder.ToTable("Banners");

            builder.HasKey(field => field.Id);

            builder.Property(field => field.Order)
                .HasColumnType("smallint")
                .IsRequired();

            builder.Property(field => field.FilePath)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();

            base.ConfigureBasicFields(builder);
        }
    }
}
