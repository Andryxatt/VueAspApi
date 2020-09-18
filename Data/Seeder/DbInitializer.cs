using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueAsp.Models;

namespace VueAsp.Data.Seeder
{
    public class DbInitializer
    {
        public static void Initialize(BazaDataBase context, IServiceProvider services)
        {
            // Get a logger
            var logger = services.GetRequiredService<ILogger<DbInitializer>>();

            // Make sure the database is created
            // We already did this in the previous step
            context.Database.EnsureCreated();

            if (!context.Brands.Any())
            {
                logger.LogInformation("Start seeding the database.");
                List<Brand> brands = new List<Brand>()
            {
                new Brand
                {
                    BrandId = Guid.NewGuid(),
                    NameBrand = "Rider",
                    Description = "Brazil summer shoes, very-good quolity"
                },
                 new Brand
                {
                    BrandId = Guid.NewGuid(),
                    NameBrand = "Ipanema",
                    Description = "Brazil summer shoes"
                },
                  new Brand
                {
                    BrandId = Guid.NewGuid(),
                    NameBrand = "Puma",
                    Description = "Sport shoes for all seasons"
                },
                   new Brand
                {
                    BrandId = Guid.NewGuid(),
                    NameBrand = "Adidas",
                    Description = "Sport shoes for all seasons"
                },
            };
                context.Brands.AddRange(brands);

                context.SaveChanges();
            }
            if (!context.Sizes.Any())
            {
                logger.LogInformation("Start seeding the database.");
             
                context.Sizes.AddRange(SizesList.sizesBabys());
                context.Sizes.AddRange(SizesList.sizesKids());
                context.Sizes.AddRange(SizesList.sizesMans());
                context.Sizes.AddRange(SizesList.sizesWomens());

                context.SaveChanges();
            }

            logger.LogInformation("Finished seeding the database.");
        }






    }
}
