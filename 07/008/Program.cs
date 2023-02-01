var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Map("/user", HandleMapUser);
app.Map("/test", appMap =>
{
    appMap.Run(async context =>
    {
        await context.Response.WriteAsync("Hello from 2nd app.Map()");
    });
});
app.Run(async context =>
{
    await context.Response.WriteAsync("Hello, World!");
});

app.Run();

static void HandleMapUser(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("Hello from 1st app.Map()");
    });
}


