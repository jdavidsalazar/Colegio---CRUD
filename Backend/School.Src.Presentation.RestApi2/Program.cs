using Microsoft.EntityFrameworkCore;
using School.Src.Core.Application.Services;
using School.Src.Core.Domain.Repositories;
using School.Src.Core.Domain.Services;
using School.Src.Infrastructure.MySqlDb.Contexts;
using School.Src.Infrastructure.MySqlDb.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddScoped<IAlumnoQueryService, AlumnoQueryService>();
builder.Services.AddScoped<IAlumnoCommandService, AlumnoCommandService>();
builder.Services.AddScoped<IProfesorQueryService, ProfesorQueryService>();
builder.Services.AddScoped<IProfesorCommandService, ProfesorCommandService>();
builder.Services.AddScoped<IGradoQueryService, GradoQueryService>();
builder.Services.AddScoped<IGradoCommandService, GradoCommandService>();
builder.Services.AddScoped<IAlumnoGradoQueryService, AlumnoGradoQueryService>();
builder.Services.AddScoped<IAlumnoGradoCommandService, AlumnoGradoCommandService>();

builder.Services.AddScoped<IAlumnoRepository, AlumnoRepository>();
builder.Services.AddScoped<IProfesorRepository, ProfesorRepository>();
builder.Services.AddScoped<IGradoRepository, GradoRepository>();
builder.Services.AddScoped<IAlumnoGradoRepository, AlumnoGradoRepository>();


// Configure DbContex
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseMySql(
//        builder.Configuration.GetConnectionString("DefaultConnection"),
//        new MySqlServerVersion(new Version(8, 0, 21))
//    ));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        "Server=.;Database=Colegio;User Id=JD\\57313;Trusted_Connection=True;TrustServerCertificate=True;"
    ));

// Configure AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
