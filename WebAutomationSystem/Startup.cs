using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAutomationSystem.Areas.UserArea.Controllers.Component;
using WebAutomationSystem.Areas.UserArea.Hubs;
using WebAutomationSystem.CommonLayer.PublicClass;
using WebAutomationSystem.CommonLayer.Services;
using WebAutomationSystem.DataModelLayer;
using WebAutomationSystem.DataModelLayer.CqrsCommands.NewsCommand.Models;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.Repository;
using WebAutomationSystem.DataModelLayer.Services;

namespace WebAutomationSystem
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
            //DataBaseService
            services.AddDbContext<ApplicationDbContext>(option =>
            option.UseSqlServer(Configuration.GetConnectionString("AutomationConnectionString"),
                datamodel => datamodel.MigrationsAssembly("WebAutomationSystem.DataModelLayer")));

            //Identity Service
            services.AddIdentity<ApplicationUsers, ApplicationRoles>(option => {
                option.Password.RequireDigit = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireLowercase = false;
                option.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            services.AddScoped<IUploadFiles, UploadFiles>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserJobRepository, UserJobRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ILettersRepository, LettersRepository>();
            services.AddScoped<IUserInfoWithJobRepository, UserInfoWithJobRepository>();
            services.AddScoped<INotationRepository, NotationRepository>();
            services.AddScoped<ILeaveRepository, LeaveRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IForignDocumentRepository, ForignDocumentRepository>();
            services.AddScoped<IBlobRepository, BlobRepository>();
            services.AddScoped<IBlobDescriptionRepository, BlobDescriptionRepository>();
            services.AddScoped<ISecretariatTypeRepository, SecretariatTypeRepository>();

            
            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews();
            
            //MediatR
            services.AddMediatR(typeof(GetAllNewsCommandModel).GetTypeInfo().Assembly);

            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.AddSignalR();
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


            //Error 404
            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/Home/Err404";
                    await next();
                }
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //AdminArea
                endpoints.MapAreaControllerRoute(
                    "AdminArea",
                    "AdminArea",
                    "AdminArea/{controller=UserManager}/{action=Index}/{id?}");
                //UserArea
                endpoints.MapAreaControllerRoute(
                    "UserArea",
                    "UserArea",
                     "UserArea/{controller=UserHome}/{action=Index}/{id?}");
                //default
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");

                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Account}/{action=Login}/{id?}");
                //SignalR
                endpoints.MapHub<LetterHub>("/myownHub");
            });
        }
    }
}
