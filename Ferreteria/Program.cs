using Ferreteria.Models;
using Ferreteria.Repositories;
using Ferreteria.Repositories.Interfaces;
using Ferreteria.Services;
using Ferreteria.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IUbicacionRepository, UbicacionRepository>();
builder.Services.AddScoped<IUbicacionService, UbicacionService>();

// aca cambien el nombre de la variable por el nombre de la coneccion del appseting de cada uno
string connectionName = "FabrizioConnection";

builder.Services.AddDbContext<FerreteriaContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString(connectionName)
    )
);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();