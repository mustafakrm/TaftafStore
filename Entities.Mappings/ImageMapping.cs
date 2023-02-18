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
    public class ImageMapping : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {

            builder.ToTable("Images");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ImageName).HasMaxLength(2000).HasColumnType("varchar").IsRequired();
            builder.Property(x => x.ImagePath).HasColumnType("nvarchar");

            builder.HasOne(p => p.Product).WithMany(i => i.Images).HasForeignKey(p => p.ProductId);

        }
    }
}
