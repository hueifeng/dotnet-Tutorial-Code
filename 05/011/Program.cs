using _011;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("person.json", true, true)
            .Build();
var services = new ServiceCollection();
var optionsMonitor = services
    .AddOptions()
    .Configure<Person>(configuration)
    .BuildServiceProvider().GetRequiredService<IOptionsMonitor<Person>>();

optionsMonitor.OnChange(o =>
{
    Console.WriteLine($"时间：{DateTime.Now}，Age：{o.Age}");
});
Console.ReadLine();
