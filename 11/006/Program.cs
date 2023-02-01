using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

var provider = new FileExtensionContentTypeProvider();
provider.Mappings[".less"] = "text/css";
provider.Mappings[".htm3"] = "text/html";
provider.Mappings[".image"] = "image/png";

app.UseStaticFiles(new StaticFileOptions
{
    ContentTypeProvider = provider
});

app.Run();
