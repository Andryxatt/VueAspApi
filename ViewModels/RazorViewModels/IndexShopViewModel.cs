using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueAsp.Models;

namespace VueAsp.ViewModels.RazorViewModels
{
    public class IndexShopViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagePagilListViewModel PagePagilList { get; set; }
    }
}
