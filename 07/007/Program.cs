var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Use(next =>
{
    return async (context) =>
    {
        await context.Response.WriteAsync("Before Invoke from 1st app.Use()\n");
        await next(context);
        await context.Response.WriteAsync("After Invoke from 1st app.Use()\n");
    };
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync("Hello from 1st app.Run()\n");
});

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello, World!");
});

app.Run();
