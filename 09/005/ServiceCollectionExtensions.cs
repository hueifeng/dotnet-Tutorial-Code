using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Localization;

namespace _005
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddJsonLocalizer(this IServiceCollection services, IFileProvider
 fileProvider)
        {
            services.AddSingleton<IStringLocalizerFactory>
            (new JsonStringLocalizerFactory(fileProvider));
            services.AddTransient(typeof(IStringLocalizer<>), typeof(StringLocalizer<>));
            return services;
        }

    }
}
