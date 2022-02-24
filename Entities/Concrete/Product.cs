using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product : EntityBase
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public DateTime? AddedDate { get; set; }
        public int? UnitsInstock { get; set; }
        public Guid SubCategoryId { get; set; }

        public SubCategory SubCategory { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
