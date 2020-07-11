using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueAsp.ViewModels
{
    public class ProductPhotos
    {
        public Guid ProductId { get; set; }
        public IFormFileCollection Photos { get; set; }
    }
}
