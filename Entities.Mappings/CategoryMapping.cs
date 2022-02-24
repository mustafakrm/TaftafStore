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
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CategoryName).HasMaxLength(2000).HasColumnType("varchar").IsRequired();

            builder.HasMany(sc => sc.SubCategories).WithOne(c => c.Category).HasForeignKey(sc => sc.CategoryId);

        }
    }
}
