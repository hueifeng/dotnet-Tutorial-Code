
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Localization;

namespace App3;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddJsonLocalizer(this IServiceCollection services, IFileProvider fileProvider, IDistributedCache distributedCache)
    {
        services.AddSingleton<IStringLocalizerFactory>
        (new JsonStringLocalizerFactory(fileProvider));
        services.AddTransient(typeof(IStringLocalizer<>), typeof(StringLocalizer<>));
        return services;
    }
}
