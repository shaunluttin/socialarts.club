using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using socialarts.club.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using socialarts.club.TagHelpers.Bootstrap4;
using Microsoft.AspNetCore.SpaServices.Webpack;
using socialarts.club.ViewComponents.Extensions;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using AspNet.Security.OpenIdConnect.Primitives;

namespace socialarts.club
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
            services.AddLogging();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.ClaimsIdentity.UserNameClaimType = OpenIdConnectConstants.Claims.Name;
                options.ClaimsIdentity.UserIdClaimType = OpenIdConnectConstants.Claims.Subject;
                options.ClaimsIdentity.RoleClaimType = OpenIdConnectConstants.Claims.Role;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
            {

                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
                options.UseOpenIddict();
            });

            services
                // AddDefaultIdentity encapsulates the following:
                //      .AddAuthentication
                //      .AddIdentityCookies
                //      .AddIdentityCore
                //      .AddDefaultUI
                //      .AddDefaultTokenProviders
                // See https://github.com/aspnet/Identity for details.
                .AddDefaultIdentity<IdentityUser>()
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddOpenIddict()
                .AddCore(options =>
                {
                    options
                        .UseEntityFrameworkCore()
                        .UseDbContext<ApplicationDbContext>();
                })
                .AddServer(options =>
                {
                    options.UseMvc();
                    options.EnableAuthorizationEndpoint("/connect/authorize");

                    // TODO: answer these questions.
                    // what is the purpose of the token endpoint? 
                    // do we need it for our use case?
                    options.EnableTokenEndpoint("/connect/token");
                    options.AddEphemeralSigningKey();
                    options.AllowImplicitFlow();
                })
                .AddValidation();

            services
                .AddMvc()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AddFolderRouteParameter("/Tools", "{id:int?}");
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSingleton<BootstrapTagHelperService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
