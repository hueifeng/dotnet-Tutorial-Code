using _005;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("company.json")
            .Build();

var services = new ServiceCollection()
    .Configure<Company>("Company1", configuration.GetSection("Company1"))
    .Configure<Company>("Company2", configuration.GetSection("Company2"));
var options = services.BuildServiceProvider()
    .GetRequiredService<IOptionsSnapshot<Company>>();
var company1 = options.Get("Company1");
var company2 = options.Get("Company2");
Console.WriteLine($"Company1：{company1.Title}");
Console.WriteLine($"Company2：{company2.Title}");
