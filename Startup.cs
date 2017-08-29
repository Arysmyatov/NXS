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
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using NXS.Core.Auth;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using NXS.Helpers;
using Microsoft.AspNetCore.Http;
using NXS.Services.Abstract;
using NXS.Services.Logger;
using NXS.Migrations;
using NXS.Services.Email;
using NXS.Services.User;

namespace NXS
{
    public class Startup
    {
        private const string SecretKey = "iNivDmHLpUA223sqsfhqGbMRdRj1PVkH"; // todo: get this from somewhere secure
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                builder = builder.AddUserSecrets<Startup>();
            }
            builder = builder.AddEnvironmentVariables();
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
            services.AddScoped<IVariableXlsDescriptionRepository, VariableXlsDescriptionRepository>();
            services.AddScoped<ISubVariableRepository, SubVariableRepository>();
            services.AddScoped<IDataRepository, DataRepository>();
            services.AddScoped<IVariableDataRepository, VariableDataRepository>();
            services.AddScoped<ISubVariableDataRepository, SubVariableDataRepository>();
            services.AddScoped<IVariableXlsRepository, VariableXlsRepository>();
            services.AddScoped<IProcessSetRepository, ProcessSetRepository>();
            services.AddScoped<ICommodityRepository, CommodityRepository>();
            services.AddScoped<ICommoditySetRepository, CommoditySetRepository>();
            services.AddScoped<IAttributeRepository, AttributeRepository>();
            services.AddScoped<IUserConstraintRepository, UserConstraintRepository>();
            services.AddScoped<IRegionAgrigationTypeRepository, RegionAgrigationTypeRepository>();
            services.AddScoped<IAgrigationXlsDescriptionRepository, AgrigationXlsDescriptionRepository>();
            services.AddScoped<IAgreegationSubVariableRepository, AgreegationSubVariableRepository>();
            services.AddScoped<IContactUsMessageRepository, ContactUsMessageRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IXlsService, XlsService>();
            services.AddTransient<IExcelImportDataService, ExcelImportDataService>();
            services.AddTransient<AggregationSumCulculationService, AggregationSumCulculationService>();
            services.AddTransient<AggregationSumWorldCulculationService, AggregationSumWorldCulculationService>();
            services.AddTransient<IXlsStorage, FileSystemXlsStorage>();
            services.AddTransient<IUserActivityService, UserActivityService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDbContext<NxsDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            //services.AddDbContext<NxsDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Production")));

            services.AddSingleton<IJwtFactory, JwtFactory>();
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddCors();

            // jwt wire up
            // Get options from app settings
            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

            // Configure JwtIssuerOptions
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });

            // api user claim policy
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiUser", policy => policy.RequireClaim(Constants.Strings.JwtClaimIdentifiers.Rol, Constants.Strings.JwtClaims.ApiAccess));
                options.AddPolicy("RequireAdministratorRole", policy => policy.RequireClaim(Constants.Strings.JwtClaimIdentifiers.Rol, Constants.Strings.JwtClaims.AdminRole));
            });

            services.AddIdentity<NxsUser, IdentityRole>
                (o =>
                {
                    // configure identity options
                    o.Password.RequireDigit = false;
                    o.Password.RequireLowercase = false;
                    o.Password.RequireUppercase = false;
                    o.Password.RequireNonAlphanumeric = false;
                    o.Password.RequiredLength = 6;
                })
                .AddEntityFrameworkStores<NxsDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, NxsDbContext context)
        {
            // DbInitializer.InitializeAync(context);

            loggerFactory
                    .AddConsole();
            loggerFactory.AddProvider(new NxsLoggerProvider());
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddFile("Logs/NXS-log-{Date}.txt");
            // loggerFactory.AddDebug();

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

            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = false,
                ClockSkew = TimeSpan.Zero
            };

            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = tokenValidationParameters
            });

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseCors(builder =>
                builder.WithOrigins("http://www.theresourcenexus.co.uk",
                                     "http://theresourcenexus.co.uk",
                                     "http://localhost:5000")
                                     .AllowAnyHeader());

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
