using _008;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("person.json")
    .Build();
var services = new ServiceCollection();
var person1 = services
    .Configure<Person>(configuration)
    .BuildServiceProvider()
    .GetRequiredService<IOptions<Person>>();

Console.WriteLine($"person1：{person1.Value.Age}");
services.PostConfigure<Person>(persion =>
{
    persion.Age = 10;
});
var
person2 = services.BuildServiceProvider().GetRequiredService<IOptions<Person>>();
Console.WriteLine($"person2：{person2.Value.Age}");
