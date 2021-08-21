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
    class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(x => x.ItemId);
            builder.Property(x => x.ItemName).IsRequired();
            builder.Property(x => x.CategoryId).IsRequired();
            builder.Property(x => x.UnitPrice).IsRequired();
            builder.HasOne<Category>()          // People has one County
             .WithMany()                   // County has many people
             .HasForeignKey(x => x.CategoryId);
        }
    }
     
}
