using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace PremierLigApi.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                var result = JsonSerializer.Serialize(new
                {
                    StatusCode = 500,
                    Message = "Beklenmeyen bir hata oluştu."
                });

                await context.Response.WriteAsync(result);
            }
        }
    }
}
