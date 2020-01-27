using IAS.Data.Core2.Extensions;
using Inventware.Domain.Core2.Entities;
using Inventware.Domain.Core2.Value_Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace Inventware.Data.Core2.Mappings
{
    public class CustomerMap : EntityTypeConfiguration<Customer, Guid>, IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Table Name
            builder.ToTable("Customers");

            // Primary Key
            builder.HasKey(field => field.Id);

            builder.Property(field => field.Name)
                .HasColumnType("varchar(120)")
                .HasMaxLength(120)
                .IsRequired();

            builder.OwnsOne<Location>(field => field.Location, cb => {
                cb.Property(fieldCb => fieldCb.AddressOne)
                    .HasColumnType("varchar(120)")
                    .HasMaxLength(120)
                    .IsRequired();
                cb.Property(fieldCb => fieldCb.AddressTwo)
                    .HasColumnType("varchar(120)")
                    .HasMaxLength(120);
                cb.Property(fieldCb => fieldCb.City)
                    .HasColumnType("varchar(90)")
                    .HasMaxLength(120)
                    .IsRequired();
                cb.Property(fieldCb => fieldCb.State)
                    .IsRequired();
                cb.Property(fieldCb => fieldCb.ZipCode)
                    .HasColumnType("varchar(9)")
                    .HasMaxLength(120)
                    .IsRequired();
            });

            base.ConfigureBasicFields(builder);
        }
    }
}
