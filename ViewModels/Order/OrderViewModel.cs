using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VueAsp.Models;

namespace VueAsp.ViewModels.Order
{
    public class OrderViewModel
    {
        [Required]
        public AddressOrder Address { get; set; }
        public Models.User User { get; set; }
        [Display(Name ="Прізвище")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Ім'я")]
        [Required]
        public string LastName { get; set; }
        public IList<CartProduct> Products { get; set; } = new List<CartProduct>();
       
    }
}
