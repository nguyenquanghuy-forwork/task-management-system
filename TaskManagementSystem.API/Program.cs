using TaskManagementSystem.Application.Common.Mapping;
using TaskManagementSystem.Application.Extensions;
using TaskManagementSystem.Application.Features.Tasks.Commands;
using TaskManagementSystem.Infrastructure.DependencyInjection;
using TaskManagementSystem.Infrastructure.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplicationServices();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateTaskCommand).Assembly));
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddControllers();

// Add JWT Authentication
JwtAuthenticationConfig.Configure(builder.Services, builder.Configuration);

// Cấu hình Swagger
SwaggerConfig.Configure(builder.Services);

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // Tùy chỉnh Swagger UI để có thể nhập token
        c.OAuthClientId("swagger-ui"); // Client ID của Swagger UI (nếu có yêu cầu)
        c.OAuthAppName("Swagger UI - TaskManagementSystem");
    });
}

app.UseHttpsRedirection();
// Map controllers and configure the middleware
app.MapControllers();
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
