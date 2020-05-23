using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LazZiya.ExpressLocalization;
using System.Globalization;
using MultiCulturalBlog.LocalizationResources;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using MultiCulturalBlog.Infrastructure.Data;
using MultiCulturalBlog.Options;
using MultiCulturalBlog.Extensions;
using MultiCulturalBlog.Model.Interfaces;
using MultiCulturalBlog.Models;
using MultiCulturalBlog.Helpers;

namespace MultiCulturalBlog
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
            services.AddRazorPages()
                 .AddRazorPagesOptions(options =>
                 {
                     options.Conventions.AddPageRoute("/Blog/Index", "/");
                     options.Conventions.AddPageRoute("/Blog/Index", "home");
                     options.Conventions.AddPageRoute("/Blog/Index", "index");
                     options.Conventions.AddPageRoute("/Blog/Index", "/Blog/Index");
                     options.Conventions.AddPageRoute("/Blog/Create", "/Blog/Create");
                     options.Conventions.AddPageRoute("/Blog/Details", "/Blog/Details/{Id}");
                     options.Conventions.AddPageRoute("/Blog/Update", "/Blog/Update/{Id}");
                 });
            var cultures = new[]
                {
                    new CultureInfo("fr"),
                    new CultureInfo("en"),
                };

            // Bind database options. Invalid configuration will terminate the application startup.
            var connectionStringsOptions =
              Configuration.GetSection("ConnectionStrings").Get<ConnectionStringsOptions>();
            var cosmosDbOptions = Configuration.GetSection("CosmosDb").Get<CosmosDbOptions>();
            var (serviceEndpoint, authKey) = connectionStringsOptions.ActiveConnectionStringOptions;
            var (databaseName, collectionData) = cosmosDbOptions;
            var collectionNames = collectionData.Select(c => c.Name).ToList();
            services.Configure<AzureStorageConfig>(Configuration.GetSection("AzureStorageConfig"));
            services.AddMvc()
             .AddExpressLocalization<ExpressLocalizationResource, ViewLocalizationResource>(
             ops =>
             {
                 ops.ResourcesPath = "LocalizationResources";
                 ops.RequestLocalizationOptions = o =>
                 {
                     o.SupportedCultures = cultures;
                     o.SupportedUICultures = cultures;
                     o.DefaultRequestCulture = new RequestCulture("en");
                 };
             });
            services.AddCosmosDb(serviceEndpoint, authKey, databaseName, collectionNames);
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<ICommonHelper, CommonHelper>();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseRequestLocalization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }

    }
}
