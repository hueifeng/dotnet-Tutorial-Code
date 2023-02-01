using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MiniConfig.Client;

namespace MiniConfig
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var source = new SimpleConfigurationSource
            {
                ConfigurationName = "test.json",
                ConfigurationServiceUri = "https://localhost:44360/configuration/"
            };
            IConfiguration configuration = new ConfigurationBuilder()
                .AddSimpleSource(source)
                .Build();
            while (true)
            {
                var key = configuration.GetValue<string>("key");
                Console.WriteLine($"时间：{DateTime.Now}，Key：{key}");
                await Task.Delay(TimeSpan.FromSeconds(10));
            }
            Console.ReadLine();
        }
    }
}
