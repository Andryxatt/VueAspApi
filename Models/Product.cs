using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

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
        public float PriceSalleUS { get; set; }
        public float PriceSalleUAH { get; set; }
        public int? CountBoxes { get; set; }
        public int? CountPairsInBox { get; set; }
        public string SizesInBox { get; set; }
        public Guid? BrandId { get; set; }
        public Brand Brand { get; set; }
        public Guid? SubId { get; set; }
        public bool isDiscount { get; set; } = false;
        public int? DiscountUS { get; set; }
        public int? DiscountUAH { get; set; }
        [Timestamp]
        public byte[] Timestamp { get; set; }
        public SubCategory SubCategory { get; set; }
        public List<Photo> Photos { get; set; }
        public virtual ICollection<ProdSizes> Sizes { get; set; }
    
        public float SetPrice(float curse = 29)
        {
            return PriceSalleUS * curse;
        }
    }
}
