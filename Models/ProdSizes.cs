using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VueAsp.Models
{
    public class ProdSizes
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
       
        public Guid SizeId { get; set; }
        public virtual Size Size { get; set; }
        public int Count { get; set; }
    }
}
