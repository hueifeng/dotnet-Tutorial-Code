using _005;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var services = new ServiceCollection();
var assembly = Assembly.Load("app");
var typeList = assembly.GetTypes().Where(t =>
    t.GetCustomAttribute<TransientServiceAttribute>()?.GetType() == typeof(TransientServiceAttribute));

var dic = new Dictionary<Type, Type[]>();
foreach (var type in typeList)
{
    var interfaces = type.GetInterfaces();
    dic.Add(type, interfaces);
}
if (dic.Keys.Count > 0)
{
    foreach (var instanceType in dic.Keys)
    {
        foreach (var interfaceType in dic[instanceType])
        {
            services.AddTransient(interfaceType, instanceType);
        }
    }
}
var serviceProvider = services.BuildServiceProvider();
var sample = serviceProvider.GetRequiredService<ISample>();
Console.WriteLine(sample.Id);


[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class TransientServiceAttribute : Attribute
{
}
