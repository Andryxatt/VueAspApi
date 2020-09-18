using Microsoft.AspNetCore.Identity;
using System;
namespace VueAsp.Models
{
    public class User : IdentityUser
    {
        public DateTime? Birthday { get; set; }
    }
}
