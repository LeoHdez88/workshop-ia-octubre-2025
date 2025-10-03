
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Configuración CORS
var allowedOrigin = "http://localhost:5127";
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.WithOrigins(allowedOrigin)
              .AllowAnyHeader()
              .AllowAnyMethod()
    );
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inyección de dependencias
builder.Services.AddDbContext<backend.Data.AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AzureSql")));
builder.Services.AddScoped<backend.Repositories.ICompanyRepository, backend.Repositories.CompanyRepository>();
builder.Services.AddScoped<backend.Services.ICompanyService, backend.Services.CompanyService>();

builder.Services.AddScoped<backend.Repositories.ILocationRepository, backend.Repositories.LocationRepository>();
builder.Services.AddScoped<backend.Services.ILocationService, backend.Services.LocationService>();

    // Registrar IIndustryRepository e IIndustryService
    builder.Services.AddScoped<backend.Repositories.IIndustryRepository, backend.Repositories.IndustryRepository>();
    builder.Services.AddScoped<backend.Services.IIndustryService, backend.Services.IndustryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Usar CORS
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
