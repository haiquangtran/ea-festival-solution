using System;
using System.Net;
using AutoMapper;
using EA.Festival.ApplicationCore;
using EA.Festival.Domain.Interfaces;
using EA.Festival.Infrastructure.Services;
using EA.Festival.Web.Models.Mappings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EA.Festival.Web
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
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            ConfigureDependencies(services);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
        }

        #region Private methods

        private void ConfigureDependencies(IServiceCollection services)
        {
            // Register services
            RegisterServices(services);
           
            // Register mapping profiles
            RegisterMappingProfiles(services);
        }

        private void RegisterServices(IServiceCollection services)
        {
            // Set up AppConfig from app.settings
            services.AddOptions();
            services.Configure<AppConfig>(Configuration.GetSection("AppConfig"));
            services.AddSingleton(Configuration);

            // Setup services
            services.AddHttpClient<IMusicFestivalApiClient, MusicFestivalApiClient>(client =>
            {
            client.DefaultRequestHeaders.Add(HttpRequestHeader.ContentType.ToString(), "application/json");
            client.BaseAddress = new Uri(Configuration[Constants.AppSettingNames.MusicFestivalApiBaseAddress]);
                client.Timeout = TimeSpan.FromSeconds(int.Parse(Configuration[Constants.AppSettingNames.ApiTimeoutSeconds]));
            });
        }

        private void RegisterMappingProfiles(IServiceCollection services)
        {
            // Setup Mapping profiles
            Mapper.Initialize(config => config.AddProfile<MappingProfile>());

            services.AddAutoMapper(typeof(MappingProfile));
        }

        #endregion
    }
}
