using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueAsp.Models;

namespace VueAsp.Data
{
    public class BazaDataBase : IdentityDbContext<User>
    {
        public BazaDataBase(DbContextOptions<BazaDataBase> options)
           : base(options)
        {
            Database.EnsureCreated();
        }
       
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<ProdSizes> ProdSizes { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<AddressOrder> AddressOrders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }



    }
}
