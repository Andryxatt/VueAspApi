using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VueAsp.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid CategoryId { get; set; }
        public string NameCategory { get; set; }
        public string Description { get; set; }
        public virtual List<SubCategory> SubCategories { get; set; }
    }
}
