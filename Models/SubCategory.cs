using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VueAsp.Models
{
    public class SubCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid SubId { get; set; }
        public string NameSub { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
      
    }
}
