using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DR_Annotate.Models;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.AspNet.Authentication.Cookies;
using System.Net;

namespace DR_Annotate
{
    public class Startup
    {
        public static IConfigurationRoot Configuration;

        public Startup(IApplicationEnvironment AppEnv)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(AppEnv.ApplicationBasePath)
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables();
            Configuration = builder.Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config =>
            {
#if !DEBUG
                config.Filters.Add(new RequireHttpsAttribute());
#endif
            })
            .AddJsonOptions(opt =>
            {
                opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            //services.AddIdentity<DR_AnnotateUser, IdentityRole>(config =>
            //{
            //    config.User.RequireUniqueEmail = true;
            //    config.Password.RequiredLength = 8;
            //    config.Cookies.ApplicationCookie.LoginPath = "/Auth/Login";
            //    config.Cookies.ApplicationCookie.Events = new CookieAuthenticationEvents()
            //    {
            //        OnRedirectToLogin = ctx =>
            //        {
            //            if (ctx.Request.Path.StartsWithSegments("/api") &&
            //                ctx.Response.StatusCode == (int)HttpStatusCode.OK)
            //            {
            //                ctx.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            //            }
            //            else
            //            {
            //                ctx.Response.Redirect(ctx.RedirectUri);
            //            }
            //            return Task.FromResult(0);
            //        }
            //    };
            //})
            //services.AddEntityFrameworkStores<DR_AnnotateContext>();

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<DR_AnnotateContext>();
            services.AddTransient<DR_AnnotateContextSeedData>();

            services.AddLogging();

            services.AddScoped<IDR_AnnotateRepository, DR_AnnotateRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, DR_AnnotateContextSeedData seeder, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddDebug(LogLevel.Warning);

            app.UseStaticFiles();

            //app.UseIdentity();

            //Mapper.Initialize(config =>
            //{
            //    config.CreateMap<Model, ViewModel>().ReverseMap();
            //});

            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "App", Action = "Index" }
                    );
            });
            seeder.EnsureSeedData();
        }
        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}