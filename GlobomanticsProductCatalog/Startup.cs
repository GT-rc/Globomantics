using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlobomanticsProductCatalog.Data;
using GlobomanticsProductCatalog.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GlobomanticsProductCatalog
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // LOCAL CONNECTION STRING
            //const string connectionString = @"Server=(localdb)\mssqllocaldb;" +
            //    "Database=GlobomanticsBookDb;" + 
            //    "Trusted_Connection=True";
            // DEVELOPMENT CONNECTION STRING
            //const string connectionString = @"Server=devsql.globomantics.com;" +
            //    "Database=Globomantics_Dev;" +
            //    "User Id=globomanticsCatalogUser;" +
            //    "Password=58nx761";
            // STAGING CONNECTION STRING
            //const string connectionString = @"Server=stgsql.globomantics.com;" +
            //    "Database=Globomantics_Stg;" +
            //    "User Id=globomanticsCatalogUser;" +
            //    "Password=k8erv91x";
            // PRODUCTION CONNECTION STRING
            //const string connectionString = @"Server=prosql.globomantics.com;" +
            //    "Database=GlobomanticsBook;" +
            //    "User Id=globomanticsCatalogUser;" +
            //    "Password=Pzxy107ba";

            var connectionString = Configuration.GetConnectionString("AppDb");

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddSingleton<OrderApiClient>();

            services.Configure<AppConfig>(Configuration.GetSection("AppConfig"));
            services.Configure<OrderApiClientConfig>(Configuration.GetSection("OrderApiClientConfig"));
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

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<AppDbContext>();
                context.Database.Migrate();
                SeedData.Execute(context);
            }
        }
    }
}
