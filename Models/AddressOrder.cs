using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VueAsp.Models
{
    public class AddressOrder
    {
        [Key]
        public Guid Id { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string City { get; set; }
        public string Streat { get; set; }
        public string NumberBuiding { get; set; }
        public string NumberAppartments { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public Guid OrderId { get; set; }
    }
}
