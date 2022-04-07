using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyNamespace.Common;
using MyNamespace.Common.Configuration;
using Steeltoe.Extensions.Logging;
using Steeltoe.Management.Endpoint;

namespace MyNamespace.DotnetAccelerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .AddDynamicLogging()
                .UseYamlWithProfilesAppConfiguration<Program>(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        

    }
}