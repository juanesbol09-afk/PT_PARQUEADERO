using Microsoft.EntityFrameworkCore;
using Parqueadero.Infrastructura.Data;
using Parqueadero.Infrastructura.Repositorios;
using Parqueadero.Aplicacion.Servicios;
using Parqueadero.Aplicacion.Interfaces;
using Parqueadero.Infrastructura.ServiciosExternos;

var builder = WebApplication.CreateBuilder(args);

// ➤ Registrar DbContext con MySQL
builder.Services.AddDbContext<ParqueaderoDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

builder.Services.AddScoped<IVehiculoRepository, VehiculoRepository>();
builder.Services.AddScoped<IVehiculoService, VehiculoService>();
builder.Services.AddControllers();
builder.Services.AddHttpClient<IEmailService, EmailService>();

// ➤ Servicios básicos
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularPolicy",
        policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseCors("AngularPolicy");
// ➤ Swagger en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();