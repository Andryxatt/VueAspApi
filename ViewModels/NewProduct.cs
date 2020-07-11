using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VueAsp.ViewModels
{
    [Serializable]
    public class NewProduct
    {
        
        [Required(ErrorMessage ="Model name is required!"),MaxLength(50,ErrorMessage ="Maximum 50 symbols!"), MinLength(3,ErrorMessage ="Minimum 3 symbols!")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Brand shold be selected!")]
        public Guid BrandId { get; set; }
        [Required(ErrorMessage = "Price shold be inputed!")]
        public float PriceBy { get; set; }
        public Guid SubId { get; set; }
        
    }
}
