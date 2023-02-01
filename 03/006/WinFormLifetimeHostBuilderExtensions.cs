using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace _006
{
    public static class WinFormLifetimeHostBuilderExtensions
    {
        public static IHostBuilder UseWindowsForms<TMainForm>(this IHostBuilder builder) where TMainForm : Form
        {
            return builder.ConfigureServices((context, services) =>
            {
                services
                    .AddSingleton<TMainForm>()
                    .AddSingleton<IHostLifetime, WindowsFormsLifetime>()
                    .AddSingleton(c =>
    new ApplicationContext(c.GetRequiredService<TMainForm>()))
                   .AddHostedService<WindowsFormsApplicationHostedService>();
            });
        }
    }

}
