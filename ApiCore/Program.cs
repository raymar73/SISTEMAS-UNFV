using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ApiCore {
    public class Program {
        public static void Main (string[] args) {
            CreateWebHostBuilder (args).Build ().Run ();
        }

        public static IWebHostBuilder CreateWebHostBuilder (string[] args) =>
            WebHost.CreateDefaultBuilder (args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                    config.AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true);
                    config.AddCommandLine(args);
                    config.AddEnvironmentVariables();
                })
            .UseSetting ("https_port", "443")
            .UseStartup<Startup>();
    }
}