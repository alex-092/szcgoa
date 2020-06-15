using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLib.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OA.Entitys;
using OA.Entitys.OaAuthDB;
using OA.Entitys.OaCoreDB;
using OA.Entitys.OaMsgDB;
using OA.Entitys.OaSyslogDB;
using OA.MVC.Common.Base;

namespace OA.MVC
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
            services.AddControllersWithViews();
            //cache
            services.AddMemoryCache();
            //add DataBases DI
            services.AddDbContext<oa_coreContext>(options => options.UseMySql(Configuration.GetConnectionString("OaCoreMySql"), x => x.ServerVersion("5.5.64-mariadb")));
            services.AddDbContext<oa_authContext>(options => options.UseMySql(Configuration.GetConnectionString("OaAuthMySql"), x => { x.ServerVersion("5.5.64-mariadb"); x.EnableRetryOnFailure(); }));
            services.AddDbContext<oa_msgContext>(options => options.UseMySql(Configuration.GetConnectionString("OaMsgMySql"), x => { x.ServerVersion("5.5.64-mariadb"); x.EnableRetryOnFailure(); }));
            services.AddDbContext<oa_syslogContext>(options => options.UseMySql(Configuration.GetConnectionString("OaSyslogMySql"), x => { x.ServerVersion("5.5.64-mariadb"); x.EnableRetryOnFailure(); }));
            //di
            services.AddAssembly("OA.Services");
            EnginContext.Initialize(new SzcgOAEngine(services.BuildServiceProvider()));

            //other services di

            //auth code
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddAuthentication(ConfigStrings.SZCGOA_AuthenticationScheme).AddCookie(ConfigStrings.SZCGOA_AuthenticationScheme);



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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
