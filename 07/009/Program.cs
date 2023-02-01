var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapWhen(context => context.Request.Query.Keys.Contains("q"),
                        appMap =>
                        {
                            appMap.Run(async context =>
                            {
                                await context.Response.WriteAsync($"Hello Test:{context.Request.Query["q"]}");
                            });
                        });
app.Run(async context =>
{
    await context.Response.WriteAsync("Hello, World!");
});

app.Run();