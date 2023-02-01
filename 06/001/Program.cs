﻿using _001;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var host = new HostBuilder()
        .ConfigureLogging(logging =>
        {
            logging.AddConsole();
        })
        .ConfigureServices((hostContext, services) =>
        {
            services.AddHostedService<MyHostedService>();
        });
await host.RunConsoleAsync();
