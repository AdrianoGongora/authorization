using System.Text.Json;
using UserManager.Application.Commons.Bases;
using UserManager.Application.Commons.Exceptions;

namespace UserManager.Middleware;

public class ValidationMiddleware
{
    private readonly RequestDelegate _next;

    public ValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (ValidationException ex)
        {
            context.Response.ContentType = "application/json";
            await JsonSerializer.SerializeAsync(context.Response.Body, new BaseResponse<object>
            {
                Message = "Errores de validacion",
                Errors = ex.Errors!
            });
        }
    }
}