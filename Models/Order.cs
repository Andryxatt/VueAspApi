using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VueAsp.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateConfirm { get; set; }
        public Guid? UserId { get; set; }
        public string FirtsName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string DeliveryType { get; set; }
        public bool isApplayed { get; set; } = false;
        public float Summa { get; set; }
        [Timestamp]
        public byte[] Timestamp { get; set; }
        public ICollection<OrderItems> Items { get; set; }
       
    }
}
