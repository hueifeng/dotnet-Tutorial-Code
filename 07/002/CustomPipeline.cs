namespace _002
{
    public class CustomPipeline
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<CustomMiddleware>();
        }
    }
}