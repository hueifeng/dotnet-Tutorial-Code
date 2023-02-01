using _004;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLocalization();

var app = builder.Build();

app.UseRequestLocalization(options =>
{
    options
        .AddSupportedCultures("en", "zh")
        .AddSupportedUICultures("en", "zh")
        .RequestCultureProviders.Clear();
    options.RequestCultureProviders.Add(new CustomRequestCultureProvider());
});
await app.RunAsync();
