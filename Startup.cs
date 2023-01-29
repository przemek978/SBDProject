using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SBD.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace SBD
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
			services.AddAuthentication("CookieAuthentication")
            .AddCookie("CookieAuthentication", config =>
            {
	            config.Cookie.HttpOnly = true;
	            config.Cookie.SecurePolicy = CookieSecurePolicy.None;
	            config.Cookie.Name = "UserLoginCookie";
	            config.LoginPath = "/Login/Login";
	            config.Cookie.SameSite = SameSiteMode.Strict;
                
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdministratorRole",
                     policy => policy.RequireRole("Administrator"));
                options.AddPolicy("RequireEmployeeRole",
                     policy => policy.RequireRole("Pracownik", "Administrator"));
                options.AddPolicy("RequirePilotRole",
                     policy => policy.RequireRole("Pilot","Administrator"));
                     
            });
            services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeFolder("/Licencje", "RequireAdministratorRole");
                options.Conventions.AuthorizeFolder("/LinieLotnicze", "RequireAdministratorRole");
                options.Conventions.AuthorizeFolder("/Lotniska", "RequireAdministratorRole");
                //options.Conventions.AuthorizeFolder("/Loty", "RequireAdministratorRole");
                //options.Conventions.AuthorizeFolder("/Piloci", "RequireAdministratorRole");
                options.Conventions.AuthorizeFolder("/Pracownicy", "RequireAdministratorRole");
                options.Conventions.AuthorizeFolder("/Samoloty", "RequireAdministratorRole");
                options.Conventions.AuthorizeFolder("/Bagaze", "RequireEmployeeRole");
                options.Conventions.AuthorizeFolder("/Bilety", "RequireEmployeeRole");
                options.Conventions.AuthorizeFolder("/Pasazerowie", "RequireEmployeeRole");
                options.Conventions.AuthorizeFolder("/Loty", "RequirePilotRole");
                options.Conventions.AuthorizeFolder("/Piloci", "RequirePilotRole");
            });


            services.AddRazorPages();

            services.AddDbContext<AirPortContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("AirPortContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

			app.UseCookiePolicy();
			app.UseAuthentication();


			app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
