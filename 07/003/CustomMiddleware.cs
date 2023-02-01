using Newtonsoft.Json;

namespace _003
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var originalResponseBodyStream = context.Response.Body;

            using var memoryStream = new MemoryStream();
            context.Response.Body = memoryStream;

            await _next(context);

            context.Response.Body = originalResponseBodyStream;
            memoryStream.Seek(0, SeekOrigin.Begin);

            var readToEnd = await new StreamReader(memoryStream).ReadToEndAsync();
            var objResult = JsonConvert.DeserializeObject(readToEnd);
            var result = CustomApiResponse.Create(context.Response.StatusCode, objResult, context.TraceIdentifier);
            await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
        }
    }
}


