using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StructureMap;
using FlightSearchApi.Contracts;
using FlightSearchApi.Core;
using FlightSearchApi.Core.Validator;
using FlightSearchApi.Plugins;

namespace FlightSearchApi.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMemoryCache();
            var container = new Container(config =>
                {
                    config.For<IFlightService>().Use<FlightService>();
                    config.For<IValidator>().Use<SearchByFlightNumberValidator>();
                    config.For<IFlightEngine>().Use<FlightEngine>();
                    config.For<IFlightAdapter>().Use<MockFlightAdapter>();
                    config.For<IDataStore>().Use<FlightFileStore>();
                    config.For<ICacheProvider>().Use<MemoryCacheProvider>();
                    config.For<IFlightDataService>().Use<FlightDataService>();
                  
                    config.Populate(services);
                });
          

            return container.GetInstance<IServiceProvider>();
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMiddleware<LoggingMiddleware>();
            app.UseMvc();
        }
    }
}
