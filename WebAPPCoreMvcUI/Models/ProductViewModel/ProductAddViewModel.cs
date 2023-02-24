using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace WebAPPCoreMvcUI.Models.ProductViewModel
{
    public class ProductAddViewModel
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public DateTime? AddedDate { get; set; }
        public int? UnitsInstock { get; set; }
        public bool IsDeleted { get; set; }
        public Guid SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public ICollection<IFormFile> Files { get; set; }
        public List<Image> Images { get; set; }

    }
}
