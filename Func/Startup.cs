using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;
using Microsoft.OpenApi.Models;
[assembly: FunctionsStartup(typeof(Func.Startup))]

namespace Func
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            Console.WriteLine("Startup paper-less");
            Console.WriteLine("Add Logging");
            builder.Services.AddLogging();
            Console.WriteLine("Add Configuration");
            builder.Services.AddSingleton<IConfiguration>(Configuration);
            
            //AddSwagger(builder.Services);
        }

        private void AddSwagger(IServiceCollection services)
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            var resourceName = $"{currentAssembly.GetName().Name}.xml";
            var xmlCommentsFilePath = Path.Combine(AppContext.BaseDirectory, resourceName);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Exchange Rate API", Version = "v1" });
                c.IncludeXmlComments(xmlCommentsFilePath);
            });
        }
        private IConfiguration Configuration
        {
            get
            {
                var configBuilder = new ConfigurationBuilder()
                    .SetBasePath(Environment.CurrentDirectory)
                    .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables();

                return configBuilder.Build();
            }
        }

    }
}
