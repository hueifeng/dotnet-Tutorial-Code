using _006;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var services = new ServiceCollection();
var assembly = Assembly.Load("app");
services.BatchRegisterService(assembly, "Sample", ServiceLifetime.Singleton);
var serviceProvider = services.BuildServiceProvider();
var sample = serviceProvider.GetRequiredService<ISample>();
Console.WriteLine(sample.Id);