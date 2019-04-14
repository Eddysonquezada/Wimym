using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Wimym.Back
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
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMyDependencies(Configuration);

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = Configuration["Auth:Url"];
                    options.RequireHttpsMetadata = false;
                    options.ApiName = Configuration["Auth:ApiName"];

                    // Agregamos esto para especificar donde se encuentra el role
                    options.RoleClaimType = ClaimTypes.Role;
                });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                    builder.AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowAnyOrigin()
                );
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Wimym.Api", Version = "v1" });
            });

            // Automapper config
            MyMaps.Initialize();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddMyDependencies(Configuration);

            SpaParameters.ApiUrl = Configuration["Api:Url"];

            #region Identity Server
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(opts =>
            {
                opts.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme; //this is the equivalence to Authorize on controllers
                opts.DefaultChallengeScheme = "oidc";
            }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddOpenIdConnect("oidc", options =>
              {
                  options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

                  options.Authority = Configuration["Auth:Url"];
                  options.RequireHttpsMetadata = false;
                  options.GetClaimsFromUserInfoEndpoint = true;

                  options.ClientId = Configuration["Auth:ClientId"];
                  options.ClientSecret = Configuration["Auth:SecretKey"];
                  options.ResponseType = "code id_token";

                  options.Scope.Add("Wimym.Api");

                  options.SaveTokens = true;

                  // Esto ya no es necesario, me percaté que el ProfileService esta seteando correctamente los claims
                  ////an easy way to store claims is the next one, we didnt use it, because we need to do charpintery with it
                  //options.ClaimActions.Add(new JsonKeyClaimAction(ClaimTypes.Name, ClaimTypes.Name, ClaimTypes.Name));
                  //options.ClaimActions.Add(new JsonKeyClaimAction(ClaimTypes.Surname, ClaimTypes.Surname, ClaimTypes.Surname));
                  //options.ClaimActions.Add(new JsonKeyClaimAction(ClaimTypes.Uri, ClaimTypes.Uri, ClaimTypes.Uri));
                  //options.ClaimActions.Add(new JsonKeyClaimAction(ClaimTypes.Email, ClaimTypes.Email, ClaimTypes.Email));
                  //options.ClaimActions.Add(new JsonKeyClaimAction("ImageProfile", "ImageProfile", "ImageProfile"));

                  options.Events = new OpenIdConnectEvents
                  {
                      OnUserInformationReceived = async context =>
                      {
                          var claims = new List<Claim>();

                          if (context.Properties.Items.Keys.Contains(".Token.access_token"))
                          {
                              var token = context.Properties.Items[".Token.access_token"].ToString();
                              claims.Add(new Claim("access_token", token));

                              var id = context.Principal.Identity as ClaimsIdentity;
                              id.AddClaims(claims);
                          }

                          await Task.FromResult(0);
                      }
                  };

              });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            #endregion

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                    builder.AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowAnyOrigin()
                );
            });


            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>()
          .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();


            services.AddMvc(config =>
            {
                // using Microsoft.AspNetCore.Mvc.Authorization;
                // using Microsoft.AspNetCore.Authorization;
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<IAuthorizationHandler,
                ContactIsOwnerAuthorizationHandler>();

            services.AddSingleton<IAuthorizationHandler,
                ContactAdministratorsAuthorizationHandler>();

            services.AddSingleton<IAuthorizationHandler,
                ContactManagerAuthorizationHandler>();

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseAuthentication();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Wimym Api");
            });

            app.UseCors("AllowSpecificOrigin");

            app.UseMvc();

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

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseCors("AllowSpecificOrigin");

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


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
            app.UseCookiePolicy();

            app.UseAuthentication();


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

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            DbInitializer.Initialize(context);
        }
    }
}
