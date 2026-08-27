using System.Net;
using System.Text.Json;
using Book_Store_API.Exceptions;

namespace StudentManagementAPI.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }

            catch (BusinessException ex)
            {
                context.Response.StatusCode = ex.StatusCode;
                context.Response.ContentType = "application/json";

                var response = new
                {
                    message = ex.Message
                };

                await context.Response.WriteAsJsonAsync(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var response = new
                {
                    message = "An unexpected error occurred."
                };

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}