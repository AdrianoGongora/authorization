namespace UserManager.Middleware;

public static class MiddlewareExtension
{
    public static IApplicationBuilder AddMiddlewareValidation(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ValidationMiddleware>();
    }
}