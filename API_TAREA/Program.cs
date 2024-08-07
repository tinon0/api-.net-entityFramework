using API_TAREA.Data;
using API_TAREA.Mapping;
using API_TAREA.Repository;
using API_TAREA.Repository.Impl;
using API_TAREA.Services;
using API_TAREA.Services.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextDB>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings"));
    //options.UseSqlServer(builder.Configuration.GetConnectionString("Connection:ConnectionString"));

});

builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<ICursoService, CursoServiceImpl>();
builder.Services.AddScoped<ICarreraRepository, CarreraRepository>(); //van los repo y services
builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<IAlumnoRepository, AlumnoRepository>();
builder.Services.AddScoped<IAlumnoService, AlumnoServiceImpl>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddCors(options => //los CORS
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(); //los usamos

app.UseAuthorization();

app.MapControllers();

app.Run();
