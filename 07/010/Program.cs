var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseWhen(
    context =>
    context.Request.Query.Keys.Contains("q"),
                      appMap =>
                      {
                          appMap.Use(next =>
                          {
                              return async (context) =>
                              {
                                  await context.Response.WriteAsync("Before Invoke from 1st app.Use()\n");
                                  await next(context);
                                  await context.Response.WriteAsync("After Invoke from 1st app.Use()\n");
                              };
                          });
                      });
app.Run(async context =>
{
    await context.Response.WriteAsync("Hello, World!\n");
});


app.Run();


