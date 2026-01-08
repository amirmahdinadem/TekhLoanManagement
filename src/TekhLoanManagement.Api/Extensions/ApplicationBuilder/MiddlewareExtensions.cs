using TekhLoanManagement.Api.Middlewares;

namespace TekhLoanManagement.Api.Extensions.ApplicationBuilder
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddlewares(
            this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalExceptionMiddleware>();

            return app;
        }
    }
}
