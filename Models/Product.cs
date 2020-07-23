using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VueAsp.Models
{
    [Serializable]
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid ProductId { get; set; }
        public string Model { get; set; }
        public float PriceBy { get; set; }
        public Guid? BrandId { get; set; }
        public Brand Brand { get; set; }
        public Guid? SubId { get; set; }
        public  SubCategory SubCategory { get; set; }
        public  List<Photo> Photos { get; set; }
        public ICollection<ProdSizes> Sizes { get; set; }
        public  List<ProductMass> MassesProducts { get; set; }
    
    }
}
