using _004;
using Microsoft.Extensions.DependencyInjection;

new ServiceCollection()
    .AddTransient<ISample, Sample>()
    .BuildServiceProvider(new ServiceProviderOptions
    {
        ValidateOnBuild = true,
    });

