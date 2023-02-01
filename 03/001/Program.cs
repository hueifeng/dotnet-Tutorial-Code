using Microsoft.AspNetCore.Builder;

namespace app
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            app.MapGet("/", () => "Hello World!");
            app.RunAsync();

            var urls = app.Urls;
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(string.Join(",", urls)));

        }
    }
}