using Aiesec.Database.Context;
using Aiesec.ExternalServices;
using Aiesec.Service;
using Aiesec.Web.Hangfire;
using Aiesec.Web.Helper;
using Aiesec.Web.Mappings;
using Aiesec.Web.Options;
using Aiesec.Web.Resources;
using AutoMapper;
using EntityFrameworkCore.Triggers;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

namespace Aiesec.Web
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
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddDbContext<AuthContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AuthContext")));
            services.AddDbContext<DBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DBContext")));
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;


            })
                .AddViewLocalization(options => options.ResourcesPath = Settings.Constants.ResourcePath)
                .AddDataAnnotationsLocalization(options => options.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(typeof(ValidationErrors)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddLocalization(x => x.ResourcesPath = Settings.Constants.ResourcePath);
            services.ConfigureLocalization();
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddDataProtection();
            services.AddServices();
            services.AddExternalServices();
            services.AddSingleton(Configuration.GetSection("EmailServers:no-reply").Get<EmailServerNoReplyOptions>());
            services.AddScoped<SharedResource>();
            services.AddScoped<ValidationErrors>();
            services.AddScoped<ValidationChecker>();
            services.AddScoped<DataTable>();
            services.AddScoped<Constants>();
            services.AddScoped<ISelectListService, SelectListService>();
            services.AddTriggers();
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AuthContext>()
                .AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "Aiesec.Cookie";
                config.LoginPath = "/Home/Authenticate";
            });
            services.AddAuthorization(configure =>
            {
                var defaultAuthBuilder = new Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder();
                var defaultAuthPolicy = defaultAuthBuilder.RequireAuthenticatedUser()
                .Build();
            });
            services.AddHangfire(config =>
            {
                config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
               .UseSimpleAssemblyNameTypeSerializer()
               .UseDefaultTypeSerializer()
               .UseMemoryStorage();
            });
            services.AddHangfireServer();
            services.AddScoped<ISendMailJob, SendMailJob>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env
            , IBackgroundJobClient backgroundJobClient,
             IRecurringJobManager recurringJobManager,
             IServiceProvider serviceProvider)
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



            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSerilogRequestLogging();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRequestLocalization();
            app.UseMvc(routes =>
            {
                routes.MapRoute("areaRoute",
                    "{area:exists}/{controller=Users}/{action=Index}/{encryptedId?}");
                routes.MapRoute(
                    name: "default",
                    "{controller=Home}/{action=Index}/{encryptedId?}");
            });
            app.UseHangfireDashboard();
            recurringJobManager.AddOrUpdate(
                "Run every minute",
                  () => serviceProvider.GetService<ISendMailJob>().SendEmail(),
                  "* * * * *");


        }
    }
}