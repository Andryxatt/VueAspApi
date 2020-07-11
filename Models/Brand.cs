using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VueAsp.Models
{
    [Serializable]
    public class Brand
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid BrandId { get; set; }
        public string NameBrand { get; set; }
        public string Description { get; set; }
    }
}
