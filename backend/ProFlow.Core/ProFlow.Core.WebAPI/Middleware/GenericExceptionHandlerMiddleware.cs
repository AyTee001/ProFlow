using ProFlow.Core.Common.Exceptions;
using ProFlow.Core.DAL.Exceptions;
using System.Data;

namespace ProFlow.Core.WebAPI.GlobalMiddleware
{
    public class GenericExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public GenericExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            context.Response.StatusCode = exception switch
            {
                ArgumentNullException => 400,
                NotFoundException => 404,
                PreconditionFailedException => 412,
                _ => 500
            };

            return context.Response.WriteAsync(exception.Message);
        }
    }
}
