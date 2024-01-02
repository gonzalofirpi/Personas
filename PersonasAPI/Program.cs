using Microsoft.EntityFrameworkCore;
using PersonasAPI.Data;
using PersonasAPI.Entities;
using PersonasAPI.Entities.DTOs;
using PersonasAPI.Repositories;
using PersonasAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")), ServiceLifetime.Scoped);

// Personas
builder.Services.AddScoped<ICrudRepository<Persona, long>, PersonasRepository>();
builder.Services.AddScoped<IService<PersonaDTO, long>, PersonasService>();

// Autos
builder.Services.AddScoped<ICrudRepository<Auto, string>, AutosRepository>();
builder.Services.AddScoped<IService<AutoDTO, string>, AutosService>();

// Direcciones
builder.Services.AddScoped<ICrudRepository<Direccion, int>, DireccionesRepository>();
builder.Services.AddScoped<IService<DireccionDTO, int>, DireccionesService>();

// Empresas
builder.Services.AddScoped<ICrudRepository<Empresa, int>, EmpresasRepository>();
builder.Services.AddScoped<IService<EmpresaDTO, int>, EmpresasService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
