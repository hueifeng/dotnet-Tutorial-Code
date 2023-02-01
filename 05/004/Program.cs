using _004;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("person.json")
            .Build();
var person = new ServiceCollection()
    .Configure<Person>(configuration)
    .BuildServiceProvider()
    .GetRequiredService<IOptions<Person>>()
    .Value;
Console.WriteLine($"Age：{person.Age}");
Console.WriteLine($"Company：{person.Company.Title}");
Console.WriteLine("Languages：");
foreach (var item in person.Languages)
{
    Console.WriteLine(item);
}
Console.Read();