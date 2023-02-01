using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace _006
{
    public static class Extensions
    {
       public static IServiceCollection BatchRegisterService(
            this IServiceCollection services, Assembly assembly, string endWith, ServiceLifetime serviceLifetime
                = ServiceLifetime.Singleton)
        {
            IEnumerable<Type> typeList = assembly.GetTypes()
                .Where(t => !t.IsInterface && !t.IsSealed &&
                            !t.IsAbstract && t.Name.EndsWith(endWith));
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
                        switch (serviceLifetime)
                        {
                            case ServiceLifetime.Singleton:
                                services.AddSingleton(interfaceType, instanceType);
                                break;
                            case ServiceLifetime.Scoped:
                                services.AddScoped(interfaceType, instanceType);
                                break;
                            case ServiceLifetime.Transient:
                                services.AddTransient(interfaceType, instanceType);
                                break;
                        }
                    }
                }
            }
            return services;
        }
    }
}
