using FnAlmacenGEP.DataContext;
using FnAlmacenGEP.Interfaces;
using FnAlmacenGEP.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.IO;

[assembly: FunctionsStartup(typeof(FnAlmacenGEP.Startup))]

namespace FnAlmacenGEP
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            ConfigurationBuilder configurationBuilder = new();
            var configuration = configurationBuilder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            builder.Services.AddSingleton<DapperContext>();
            builder.Services.AddAutoMapper(typeof(Startup));
            builder.Services.AddMvcCore().AddNewtonsoftJson(jsonOptions =>
            {
                jsonOptions.SerializerSettings.NullValueHandling = NullValueHandling.Include;
            });

            builder.Services.AddTransient<IDatabaseService, DatabaseService>();
            builder.Services.AddSingleton<IConfiguration>(configuration);
        }
    }
}
