using _007;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("person.json")
    .Build();
var services = new ServiceCollection();
services.Configure<Persion>(configuration);
services.AddSingleton<IValidateOptions<Persion>, AgeConfigurationValidation>();
var person = services
    .BuildServiceProvider()
    .GetRequiredService<IOptions<Persion>>()
    .Value;
Console.WriteLine("Hello World!");
