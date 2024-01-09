using Api.Data;
using Api.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(Api.StartUp))]
namespace Api
{
    public class StartUp : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configuration = BuildConfiguration(builder.GetContext().ApplicationRootPath);

         
         
            builder.Services.AddScoped<IClassDatabaseSettings, ClassDatabaseSettings>();
            
            builder.Services.AddScoped<IClassService, ClassService>();
        }

        private object BuildConfiguration(string applicationRootPath)
        {
            //https://damienaicheh.github.io/azure/azure-functions/dotnet/2022/05/10/use-settings-json-azure-function-en.html
            var config =
               new ConfigurationBuilder()
                   .SetBasePath(applicationRootPath)
                   .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                   .AddJsonFile("settings.json", optional: true, reloadOnChange: true)
                   .AddEnvironmentVariables()
                   .Build();

            return config;
        }
    }

}