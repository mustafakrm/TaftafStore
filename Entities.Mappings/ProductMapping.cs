using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.ProductName).HasMaxLength(2000).HasColumnType("varchar").IsRequired();
            builder.Property(x => x.Description).HasMaxLength(2000).HasColumnType("varchar");
            builder.Property(x => x.PurchasePrice).HasColumnType("money");
            builder.Property(x => x.SalePrice).HasColumnType("money");
            builder.Property(x => x.DiscountPrice).HasColumnType("money");
            builder.Property(x => x.AddedDate).HasColumnType("date");

            builder.HasOne(sc=>sc.SubCategory).WithMany(p=>p.Products).HasForeignKey(p=>p.SubCategoryId);
            builder.HasMany(i => i.Images).WithOne(p=>p.Product).HasForeignKey(i=>i.ProductId);
        }
    }
}
