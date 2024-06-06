using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ESC.AdministrationCore;
using ESC.AdministrationCore.Infraestructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


using Microsoft.AspNetCore.Mvc.Formatters; // To use IOutputFormatter.
using ESC.AdministrationCore.Entities.DbSet;

using ESC.AdministrationCore.Infraestructure.Repositories; // To use IPackageRepository.
using Swashbuckle.AspNetCore.SwaggerUI; // To use SubmitMethod.
using Microsoft.AspNetCore.HttpLogging; // To use HttpLoggingFields.


var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de la base de datos
builder.Services.AddDbContext<AdministrationCoreDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EscolarisAdmon"));
});

// registro  en el contenedor de inyecci�n de dependencias
builder.Services.AddScoped<IPackageRepository, PackageRepository>();


// Agregar servicios de controladores
builder.Services.AddControllers();

// Configuraci�n de Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EscolarisAdmon", Version = "v1" });
});


// Construcci�n de la aplicaci�n
var app = builder.Build();

// Configuraci�n del pipeline de solicitudes HTTP
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EscolarisAdmon v1"));
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Usar CORS
app.UseCors("CorsPolicy");

// Usar autenticaci�n y autorizaci�n
app.UseAuthentication();
app.UseAuthorization();

// Mapear controladores
app.MapControllers();

// Configurar health checks
//app.MapHealthChecks("/health");

app.Run();