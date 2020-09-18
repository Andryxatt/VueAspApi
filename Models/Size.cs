using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace VueAsp.Models
{
    public class Size
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid SizeId { get; set; }
        public string SizeEU { get; set; }
        public string SizeUS { get; set; }
        public string SizeUK { get; set; }
        public string CM { get; set; }
        public Floor Floor { get; set; }
    }
    public enum Floor
    {
        Womans= 1,
        Mans = 2,
        Kids = 3,
        Babys = 4
    }
}
