using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Swagger / OpenAPI setup
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "To-Do API", Version = "v1" });
});

var app = builder.Build();

// Development environment only
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();       // Swagger JSON
    app.UseSwaggerUI();     // Swagger UI https://localhost:7058/swagger/index.html
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
