using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OdeToFood.Data;
using OdeToFood.Repository;
using OdeToFood.Repository.Interfaces;
using OdeToFood.Service;
using OdeToFood.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood
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
            //AUTHENTICATION
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;  //how do we authenticate users --> cookies, tokens or what here we use the cookie scheme
                //this tells asp.net core how we authenticate
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme; //we challenge a user to authenticate
            })
            .AddOpenIdConnect(options =>
            {
                Configuration.Bind("AzureActiveDirectory", options);
                //vaka e za azure
            })
            .AddCookie();

            services.AddControllersWithViews();

            services.AddRazorPages();

            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("OdeToFoodConnectionHome")));

            //REPOSITORIES
            services.AddTransient<IRestaurantRepository, RestaurantRepository>();

            //SERVICES
            services.AddTransient<IRestaurantService, RestaurantService>();

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseRewriter(new RewriteOptions().AddRedirectToHttpsPermanent());

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // Home/Index/4     4 is optional
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
