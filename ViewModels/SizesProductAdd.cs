using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueAsp.ViewModels
{
    public class SizesProductAdd
    {
        public Guid productId { get; set; }
        public List<ProdSize> sizes { get; set; }
    }
    public class ProdSize
    {
        public int count { get; set; }
        public Guid sizeId { get; set; }
    }
}
