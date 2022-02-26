using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ProductDetailDto : IDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string SubCategoryName { get; set; }
        public int? UnitsInStock { get; set; }
    }
}
