using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NXS.Persistence;
using AutoMapper;
using NXS.Core;
using NXS.Core.Models;
using NXS.Services.Excel;

namespace NXS
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<XlsUploadSettings>(Configuration.GetSection("XlsUploadSettings"));            
            services.AddAutoMapper();
            services.AddScoped<IXlsUploadRepository, XLsUplodRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<IScenarioRepository, ScenarioRepository>();
            services.AddScoped<IVariableGroupRepository, VariableGroupRepository>();
            services.AddScoped<IVariableRepository, VariableRepository>();
            services.AddScoped<ISubVariableRepository, SubVariableRepository>();
            services.AddScoped<IDataRepository, DataRepository>();
            services.AddScoped<IVariableXlsRepository, VariableXlsRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IXlsService, XlsService>();
            services.AddTransient<IExcelImportDataService, ExcelImportDataService>();
            services.AddTransient<IXlsStorage, FileSystemXlsStorage>();

            services.AddDbContext<NxsDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddFile("Logs/NXS-log-{Date}.txt");
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
