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
        public string SizeUA { get; set; }
        public string SizeUSA { get; set; }
       

    }
}
