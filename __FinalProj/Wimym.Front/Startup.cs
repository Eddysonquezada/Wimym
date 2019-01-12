namespace Wimym.Front
{
    using Front.Config;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Authentication.OpenIdConnect;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
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
        }
    }
}
