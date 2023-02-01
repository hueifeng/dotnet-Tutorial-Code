var builder = WebApplication.CreateBuilder(args);

builder.Services.AddResponseCaching(options => {
    options.UseCaseSensitivePaths = true;
    options.MaximumBodySize = 1024;
});
var app = builder.Build();

app.UseResponseCaching();
app.Run();
