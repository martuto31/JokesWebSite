﻿namespace AspNetCoreTemplate.Web
{
    using System.Reflection;

    using AspNetCoreTemplate.Data;
    using AspNetCoreTemplate.Data.Common;
    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Data.Repositories;
    using AspNetCoreTemplate.Data.Seeding;
    using AspNetCoreTemplate.Services.Data;
    using AspNetCoreTemplate.Services.Data.Leaderboard;
    using AspNetCoreTemplate.Services.Data.MyProfile;
    using AspNetCoreTemplate.Services.Data.SelectVOD;
    using AspNetCoreTemplate.Services.Data.Vicovete;
    using AspNetCoreTemplate.Services.Mapping;
    using AspNetCoreTemplate.Services.Messaging;
    using AspNetCoreTemplate.Web.Hubs;
    using AspNetCoreTemplate.Web.ViewModels;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("ApplicationDBContext")));

            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<CookiePolicyOptions>(
                options =>
                    {
                        options.CheckConsentNeeded = context => true;
                        options.MinimumSameSitePolicy = SameSiteMode.None;
                    });

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSignalR().
                AddAzureSignalR(this.configuration.GetConnectionString("SignalRConnection"));

            services.AddSingleton(this.configuration);

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddTransient<IEmailSender, NullMessageSender>();
            services.AddTransient<ISettingsService, SettingsService>();

            services.AddTransient<IVicoveService, VicoveSevice>();
            services.AddTransient<IVicLikeService, VicLikeService>();
            services.AddTransient<IVicForUploadService, VicForUploadService>();
            services.AddTransient<ILeaderboardService, LeaderboardService>();
            services.AddTransient<ISelectVOD, SelectVOD>();
            services.AddTransient<IFavVicoveService, FavVicoveService>();
            services.AddApplicationInsightsTelemetry();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                if (env.IsDevelopment())
                {
                    dbContext.Database.Migrate();
                }

                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                    {
                        endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapControllerRoute("default", "{controller=Vicove}/{action=NaiPopulqrni}/{id?}");
                        endpoints.MapControllerRoute("dailyVic", "{controller=Home}/{action=AddToDaily}/{id?}");
                        endpoints.MapHub<MainHub>("MainHub");
                        endpoints.MapRazorPages();
                    });
        }
    }
}
