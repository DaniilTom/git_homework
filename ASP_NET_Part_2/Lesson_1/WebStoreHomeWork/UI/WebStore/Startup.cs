using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebStore.Interfaces.Services;
using WebStore.Infrastructure.Implementations;
using WebStore.DAL.Context;
using Microsoft.EntityFrameworkCore;
using WebStore.Data;
using Microsoft.AspNetCore.Identity;
using WebStore.Domain;
using WebStore.Interfaces.Api;
using WebStore.ServiceHosting.Controllers;
using WebStore.Clients.Values;

namespace WebStore
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration conf) { Configuration = conf; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(); // добавляет сервисов для работы MVC
            services.AddSingleton<IServiceEmployeeData, EmployeesDataService>();
            //services.AddSingleton<IServiceMicrocontrollerData, MicrocontrollerDataService>();
            //services.AddSingleton<IServiceCategoryData, CategoriesDataService>();
            services.AddScoped<IServiceProductData, SqlProductData>();
            services.AddScoped<IServiceCategoryData, SqlProductData>();

            services.AddScoped<IServiceAllData, SqlProductData>();
            services.AddScoped<IServiceCart, CookiesCartService>();
            services.AddDbContext<WebStoreContext>(op => op.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<WebStoreDBInitializer>();

            services.AddTransient<IValueService, ValuesClient>();

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<WebStoreContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(cfg =>
            {
                cfg.Password.RequiredLength = 3;
                cfg.Password.RequireDigit = false;
                cfg.Password.RequireLowercase = false;
                cfg.Password.RequireNonAlphanumeric = false;

                cfg.Lockout.MaxFailedAccessAttempts = 10;
                cfg.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                cfg.Lockout.AllowedForNewUsers = true;
            });

            services.ConfigureApplicationCookie(cfg =>
            {
                cfg.Cookie.HttpOnly = true;
                cfg.Cookie.Expiration = TimeSpan.FromDays(150);
                cfg.Cookie.MaxAge = TimeSpan.FromDays(150);

                cfg.LoginPath = "/Account/Login";   // незарегистрированный пользователь требует доступ к особому ресурсу
                cfg.LogoutPath = "/Account/Logout";  // пользователь вышел
                cfg.AccessDeniedPath = "/Account/AccessDenied"; //если доступ запрещен

                cfg.SlidingExpiration = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, WebStoreDBInitializer _dbI)
        {
            _dbI.InitializeAsync().Wait();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            //app.Use(async(context, next) =>
            //{
            //    await context.Response.WriteAsync("<script>alert(\"Hey\");</script>");
            //    await next.Invoke();
            //}
            //);

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            app.UseMvc(route =>
            {
                route.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                route.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"); // ? - не обязательно, = - по умолчанию
            });
        }
    }
}
