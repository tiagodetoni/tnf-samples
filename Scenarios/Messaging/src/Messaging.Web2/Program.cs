﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;

namespace Messaging.Web2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Messaging Subscriber";

            var host = WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true);

                    config.AddEnvironmentVariables();
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    Log.Logger = new LoggerConfiguration()
                        .Enrich.WithMachineName()
                        .ReadFrom.Configuration(hostingContext.Configuration)
                        .CreateLogger();
                })
                .UseStartup<Startup>()
                .UseSerilog()
                .Build();

            host.Run();

            Log.CloseAndFlush();
        }
    }
}
