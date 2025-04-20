namespace WebApi.Middleware
{
    public class ApiKeyMiddleware
    {
            private readonly RequestDelegate _requestDelegate;
            private readonly IConfiguration _configuration;

            public ApiKeyMiddleware(RequestDelegate requestDelegate, IConfiguration configuration)
            {
                _requestDelegate = requestDelegate;
                _configuration = configuration;
            }

            public async Task InvokeAsync(HttpContext context)
            {

            //if (context.Request.Method == HttpMethods.Options)
            //{
            //    context.Response.StatusCode = StatusCodes.Status204NoContent;
            //    context.Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:5173");
            //    context.Response.Headers.Add("Access-Control-Allow-Headers", "X-Api-Key, Content-Type");
            //    context.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
            //    return;
            //}
            if (context.Request.Method == HttpMethods.Options)
            {
                context.Response.StatusCode = StatusCodes.Status204NoContent;
                context.Response.Headers["Access-Control-Allow-Origin"] = "http://localhost:5173";
                context.Response.Headers["Access-Control-Allow-Headers"] = "X-Api-Key, Content-Type";
                context.Response.Headers["Access-Control-Allow-Methods"] = "GET, POST, PUT, DELETE, OPTIONS";
                return;
            }

            if (!context.Request.Headers.TryGetValue("X-Api-Key", out var extractedApiKey))
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync("Missing Api-Key");
                    return;
                }

                var apiKey = _configuration["ApiKey"];
                Console.WriteLine($"Expected: {apiKey}, Provided: {extractedApiKey}");

                if (string.IsNullOrEmpty(apiKey) || apiKey != extractedApiKey)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Unauthorized access.");
                    return;
                }

                await _requestDelegate(context);
            }
        }
    }


