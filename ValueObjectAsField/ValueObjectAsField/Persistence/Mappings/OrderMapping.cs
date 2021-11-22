using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ValueObjectAsField.Domain.Models;

namespace ValueObjectAsField.Persistence.Mappings
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders").HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.OwnsOne(e => e.Name, map =>
            {
                map.WithOwner();
                map.Property(v => v.Firstname).HasColumnName("Firstname");
                map.Property(v => v.Lastname).HasColumnName("Lastname");
            });

            builder.OwnsOne(e => e.Address, map =>
            {
                map.WithOwner();
                map.Property(v => v.City).HasColumnName("City");
                map.Property(v => v.Street).HasColumnName("Street");
                map.Property(v => v.Unit).HasColumnName("Unit");
                map.Property(v => v.ZipCode).HasColumnName("ZipCode");
            });


            builder.OwnsMany(e => e.OrderLines, map =>
            {
                map.ToTable("OrderLines").HasKey("Id");
                map.Property<long>("Id").ValueGeneratedOnAdd();
                map.WithOwner().HasForeignKey("OrderId");

                map.Property(a => a.EachPrice);
                map.Property(a => a.ProductId);
                map.Property(a => a.Quantity);
                map.UsePropertyAccessMode(PropertyAccessMode.Field);
            });
        }

        public class OrderIdValueConverter : ValueConverter<OrderId, Guid>
        {
            public OrderIdValueConverter(ConverterMappingHints mappingHints = default)
                : base(MapTo, MapFrom, mappingHints)
            {

            }

            static Expression<Func<OrderId, Guid>> MapTo => e => e.Value;
            static Expression<Func<Guid, OrderId>> MapFrom = e => OrderId.CreateWith(e);
        }
    }
}

