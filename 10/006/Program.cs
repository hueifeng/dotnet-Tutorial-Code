var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecksUI()
    .AddInMemoryStorage();

var app = builder.Build();

app.UseHealthChecksUI();

await app.RunAsync();
