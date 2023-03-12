using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ProductWithImage
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public DateTime? AddedDate { get; set; }
        public int? UnitsInstock { get; set; }
        public bool IsDeleted { get; set; }        
        public Guid ProductId { get; set; }
        public SubCategory SubCategory { get; set; }
        public List<Image> Images { get; set; }
    }
}
