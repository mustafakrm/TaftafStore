using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Image:EntityBase
    {
        public Guid? ProductId { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }

        public Product Product { get; set; }
    }
}
