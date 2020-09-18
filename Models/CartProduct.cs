using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace VueAsp.Models
{
    public class CartProduct
    {
        [Key]
        public int? id { get; set; }
        public Product Product { get; set; }
        public int Quontity { get; set; }
        public ProdSizes SelectedSize { get; set; }
    }
}
