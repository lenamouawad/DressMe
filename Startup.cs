using DressMe.Config;
using DressMe.Repositories;
using DressMe.Services;
using DressMe.Enumerations;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DressMe
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
            // Settings
            services.Configure<DressMeDatabaseSettings>(Configuration.GetSection(nameof(DressMeDatabaseSettings)));
            services.AddSingleton<IDressMeDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DressMeDatabaseSettings>>().Value);

            services.AddCors(o => o.AddPolicy("MyPolicy", builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));
            // Hauts
            services.AddSingleton<HautRepository, HautRepository>();
            services.AddSingleton<HautsService, HautsService>();
            // Bas
            services.AddSingleton<BasRepository, BasRepository>();
            services.AddSingleton<BasService, BasService>();
            // Chaussure
            services.AddSingleton<ChaussureRepository, ChaussureRepository>();
            services.AddSingleton<ChaussuresService, ChaussuresService>();
            // Tenue
            services.AddSingleton<TenueRepository, TenueRepository>();
            services.AddSingleton<TenueService, TenueService>();
            // Article
            services.AddSingleton<ArticleService, ArticleService>();

            services.AddSingleton<StringToEnumConversions, StringToEnumConversions>();


            // Controllers
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors("MyPolicy");


            /*app.UseAuthorization();*/

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
           
        }
    }
}
