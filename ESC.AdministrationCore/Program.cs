using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ESC.AdminitrationCore;
using ESC.AdminitrationCore.Infraestructure;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AdministrationCoreDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EscolarisAdmon"));
});

// Otras configuraciones de servicios

var app = builder.Build();

// Configuración del pipeline de solicitud HTTP

app.Run();