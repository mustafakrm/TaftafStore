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
    public class SubCategoryMapping : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.ToTable("SubCategories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SubCategoryName).HasMaxLength(2000).HasColumnType("varchar").IsRequired();

            builder.HasMany(sc => sc.Products).WithOne(p => p.SubCategory).HasForeignKey(p => p.SubCategoryId);
            builder.HasOne(c => c.Category).WithMany(sc => sc.SubCategories).HasForeignKey(sc => sc.CategoryId);

        }
    }
}
