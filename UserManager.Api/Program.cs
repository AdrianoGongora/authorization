using UserManage.Infrastructure;
using UserManager.Application;
using UserManager.Authentication;
using UserManager.Middleware;

var builder = WebApplication.CreateBuilder(args);
const string cors = "Cors";

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApplication()
    .AddAuthentication(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: cors,
        corsPolicyBuilder =>
        {
            corsPolicyBuilder.WithOrigins("*");
            corsPolicyBuilder.AllowAnyMethod();
            corsPolicyBuilder.AllowAnyHeader();
        });
});

builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.AddMiddlewareValidation();

app.MapControllers();

app.Run();