namespace _001
{
    public static class MiddlewareExtension
    {
        public static void UseCustomExtension(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomMiddleware>();
        }
    }

}