using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using MvcMusicStore.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvcMusicStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace MvcMusicStore
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
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<MvcMusicStoreContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("MvcMusicStoreConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            // add support for Session variables
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // Initialise Sesssion:
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "myDefault",
                    pattern: "{action=Index}/{id?}",
                    defaults: new { 
                        controller = "Album" 
                    });

                //endpoints.MapControllerRoute(    // only use if language is English or German
                //    name: "supportedLanguages",
                //    template: "{language}/{controller=Home}/{action=Index}/{id?}",
                //    defaults: null,
                //    constraints: new { language = @"(en)|(de)" } 		// - if language isn't listed, go to the next mapping
                //    );

                //endpoints.MapControllerRoute(    // unsupported language requested
                //    name: "unsupportedLanguage",
                //    template: "{language}/{controller=Home}/{action=Index}/{id?}",
                //    defaults: null,
                //    constraints: new { language = @"[a-zA-Z]{2}" }, // if a 2-characture language was provided
                //    dataTokens: new { language = "en" }                 // - override with English
                //    );

                //endpoints.MapControllerRoute(    // no language specified
                //    name: "defaultLanguege",
                //    template: "{controller=Home}/{action=Index}/{id?}",
                //    defaults: new { language = "en" });   			// default language to English


                endpoints.MapRazorPages();
            });
        }
    }
}