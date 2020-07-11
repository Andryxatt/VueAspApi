using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VueAsp.Models
{
    public class ProductMass
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Boxes { get; set; }
        public int PairInBoxes { get; set; }
        public int PairsTotal { get; set; }
        public float priceSale { get; set; }
    }
}
