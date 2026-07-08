using Microsoft.EntityFrameworkCore;
using EmpresaModularAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. CONFIGURACIÓN DE CORS (Requerimiento para Angular)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// 2. REGISTRO DEL CONTEXTO DE BASE DE DATOS
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

// 3. CONFIGURACIÓN NATIVA DE OPENAPI (.NET 10)
builder.Services.AddOpenApi();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    // Mapea el endpoint nativo de OpenAPI
    app.MapOpenApi();
}

// 4. Aplicar CORS antes de la autorización
app.UseCors("AllowAngular");

app.UseAuthorization();

app.MapControllers();

app.Run();