using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueAsp.Models
{
    public class ProductOrderSingle : Order
    {
        public Guid ProductSize { get; set; }
        public ProdSizes prodSize { get; set; }
        public int Count { get; set; }
    }
}
