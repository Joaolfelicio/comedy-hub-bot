using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComedyHub.Core.Components;
using ComedyHub.Core.Components.Contracts;
using ComedyHub.Core.Configuration;
using ComedyHub.Core.Infrastructure.Gateway;
using ComedyHub.Core.Infrastructure.Gateway.Contracts;
using ComedyHub.Core.Services;
using ComedyHub.Core.Services.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;

namespace ComedyHub.Host
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
            services.AddOptions();
            services.AddControllers()
                    .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());
            services.AddScoped<INineGagMemeService, NineGagMemeService>();
            services.AddScoped<INineGagGateway, NineGagGateway>();
            services.AddScoped<IMemeFetcher, MemeFetcher>();
            services.AddScoped<IMemeOrchestrator, MemeOrchestrator>();
            services.AddScoped<IApplicationSettings, ApplicationSettings>();
            
            var applicationSettings = Configuration.GetSection(nameof(ApplicationSettings));
            services.Configure<IApplicationSettings>(applicationSettings);


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
