using WebC.Generic.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web_SYSList_Services;
using Web_License_Services;

namespace C_Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            //Configuration = configuration;
            //ReadDBConnString();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //new
        
            services.AddSession(); //new

            services.AddTransient<DataContext>(); //new2
            services.TryAddScoped<IGenericRepository<dynamic>, GenericRepository<dynamic>>(); //new2
            services.TryAddScoped<ISYSList_Services, SYSList_Services>(); //new2
            services.TryAddScoped<ILicense_Services, License_Services>();
        }

        //public void ReadDBConnString()
        //{
        //    var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
        //    var config = builder.Build();
        //    var connectionString = config.GetConnectionString("DefaultConnectionString");
        //}

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
            app.UseSession(); //new

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}/{val?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
