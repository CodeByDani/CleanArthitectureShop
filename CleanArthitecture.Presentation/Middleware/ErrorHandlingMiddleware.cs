using System.Net;
using Newtonsoft.Json;

namespace CleanArthitecture.Presentation.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context,e);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context,Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = JsonConvert.SerializeObject(new {error = exception.Message});
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = Convert.ToInt32(code);
            return context.Response.WriteAsync(result);
        }
    }
}
