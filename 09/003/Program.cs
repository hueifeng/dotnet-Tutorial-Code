using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.Extensions.Localization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLocalization();

var app = builder.Build();

app.UseRequestLocalization(options =>
{
    options
        .AddSupportedCultures("en", "zh")
        .AddSupportedUICultures("en", "zh")
        .SetDefaultCulture("en")
        .RequestCultureProviders.Insert(0, new RouteDataRequestCultureProvider());
});

app.MapGet("{culture}/docs", (IStringLocalizerFactory localizerFactory) =>
{
    var localizer = localizerFactory.Create("SharedResource", "App");
    return Results.Content(localizer.GetString("Message").Value);
});

await app.RunAsync();
