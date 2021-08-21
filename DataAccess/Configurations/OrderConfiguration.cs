using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.OrderId);
            builder.Property(x => x.StateId).IsRequired();
            builder.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(x => x.CustomerId);
           
            builder.HasOne<OrderState>()
                .WithMany()
                .HasForeignKey(x => x.StateId);

            builder.HasOne<OrderItem>()
                .WithMany()
                .HasForeignKey(x => x.OrderItemId);
        }
    }
}
