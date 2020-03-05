using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using search_event.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using search_event.Models;
using earch_event.Models;
using Microsoft.AspNetCore.Identity;

namespace search_event
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:EaventStore:ConnectionString"]));

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:EaventStoreIdentity:ConnectionString"]));

            services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AppIdentityDbContext>()
            .AddDefaultTokenProviders();

            services.AddTransient<IEaventRepository, EFEaventRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
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
                name: null,
                template: "{category}/Strona{eaventPage:int}",
                defaults: new { controller = "Eavent", action = "List" }
                );
                routes.MapRoute(
                name: null,
                template: "Strona{eaventPage:int}",
                defaults: new
                {
                    controller = "Eavent",
                    action = "List",
                    productPage = 1
                });
                routes.MapRoute(
                name: null,
                template: "{category}",
                defaults: new
                {
                    controller = "Eavent",
                    action = "List",
                    productPage = 1
                });
                routes.MapRoute(
                name: null,
                template: "",
                defaults: new
                {
                    controller = "Eavent",
                    action = "List",
                    productPage = 1
                });
                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");

            });
            SeedData.EnsurePopulated(app);
        }
    }
}
