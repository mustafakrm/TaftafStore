using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class SubCategory:EntityBase
    {
        public string SubCategoryName { get; set; }
        public Guid? CategoryId { get; set; }

        public Category Category { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
