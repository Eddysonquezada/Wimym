using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.Config;
using Auth.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wimym.DatabaseContext;
using Wimym.Model.Domain;

namespace Auth
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
            services.AddDbContext<ApplicationDbContext>(
               options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
               );

            services.AddIdentity<ApplicationUser, IdentityRole>(opts =>
            {
                opts.Password.RequireDigit = false;
                opts.Password.RequiredLength = 4;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireLowercase = false;
            })
     .AddEntityFrameworkStores<ApplicationDbContext>()
     .AddDefaultTokenProviders();


            // this code asociate the identity server with the asp identity
            // .AddDeveloperSigningCredential(); is just for developer, you need to use 
            // .AddSigningCredential on production ambient 
            services.AddIdentityServer()
                   .AddDeveloperSigningCredential()
                   .AddInMemoryIdentityResources(IdentityConfig.GetIdentityResources())
                   .AddInMemoryApiResources(IdentityConfig.GetApiResources())
                   .AddInMemoryClients(IdentityConfig.GetClients(
                       Configuration
                   ))
                   .AddAspNetIdentity<ApplicationUser>()
                    .AddProfileService<ProfileService>();




            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseIdentityServer();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
