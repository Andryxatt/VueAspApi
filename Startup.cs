using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VueAsp.Data;
using VueAsp.Services;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Identity;
using VueAsp.Models;

namespace VueAsp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //Default DataBase Connection
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<BazaDataBase>(options => options.UseSqlServer(connection));
            //Add Identity Authentication service
            services.AddIdentity<User, IdentityRole>()
                        .AddEntityFrameworkStores<BazaDataBase>();

            services.AddMvc();
            //Reposytory Wrapper service
            services.ConfigureRepositoryWrapper();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
          
            app.UseStaticFiles();
            app.UseAuthentication();   
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=ShopHome}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "ShopHome" });
            });
        }
    }
}
