using IoC;
using Microsoft.OpenApi.Models;

#region Builder Configuration
var builder = WebApplication.CreateBuilder(args);

// Controller Project DI
builder.Services.AddControllers();

// Swagger DI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Weather API",
        Description = "Weather API using Clean Architecture with a MongoDb as provider, " +
                      "make sure to install MongoDB Compass and connect to localhost, " +
                      "template is dockerized on the API section, programmed by José Mario Herrera Ricárdez",
        License = new OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }
    });
});

// IoC Project DI
builder.Services.AddProjectDependencies();

// CORS configuration
builder.Services.AddCors
(
    options => options.AddDefaultPolicy
    (
        policyBuilder =>
            policyBuilder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
    )
);
#endregion

#region App Configuration
var app = builder.Build();

// Middleware for request registry
app.Use(async (context, next) =>
{
    Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
    await next.Invoke();
});

// Swagger Implementation
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Weather API - Clean Architecture");
    c.RoutePrefix = string.Empty; // Hacer que Swagger UI sea la página principal
});

app.UseRouting();
app.UseCors();
app.MapControllers();

app.Run();
#endregion
