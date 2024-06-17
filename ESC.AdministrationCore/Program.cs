using Microsoft.EntityFrameworkCore;

using ESC.AdministrationCore.Infraestructure;
using ESC.AdministrationCore.Infraestructure.Repositories.Implement; // To use IPackageRepository.
using ESC.AdministrationCore.Infraestructure.Repositories.Contracts; // To use IPackageRepository.
using ESC.AdministrationCore.Extensions;
using ESC.AdministrationCore.Application.Mapping;

using Microsoft.Data.SqlClient;
using Serilog;

// Constructor de la aplicaci�n web
// para preparar y configurarla 
var builder = WebApplication.CreateBuilder(args);

// Configuraci�n conexion a la base de datos usando secrets
builder.Services.AddDbContext<AdministrationCoreDbContext>(options =>
{ 
    var conStrBuilder = new SqlConnectionStringBuilder(
                          builder.Configuration.GetConnectionString("Escolaris"));

    conStrBuilder.Password = builder.Configuration["SQL_PASSWORD"];

    options.UseSqlServer(builder.Configuration.GetConnectionString("EscolarisAdmon"));

    //var connection = conStrBuilder.ConnectionString;

});


// Register the caching service in the application�s service container To enable in-memory caching.
builder.Services.AddMemoryCache();

// M�todos de extensi�n para configrar servicios espec�ficos de la app

// Register the IDocumentTypeRepository with its implementation DocumentTypeRepository
builder.Services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();

// CORS Cross-Origin Resource Sharing permite que los recursos en un servidor web sean solicitados desde otro dominio distinto al propio dominio del servidor
// Swagger utilizando los m�todos de extensi�n
builder.Services.ConfigureCors();
builder.Services.ConfigureSwagger();

//AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Agregar servicios de controladores MVC
builder.Services.AddControllers();

// monitorear la salud de tu aplicaci�n
builder.Services.AddHealthChecks();

// manejo de logs para facilitar la depuraci�n y monitoreo de la aplicaci�n
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole();
    loggingBuilder.AddDebug();
});

// Configuraci�n de Serilog para  ver los mensajes de  _logger.LogInformation(...
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/csi-esc-administration-core.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// Configuraci�n de servicios
builder.Services.AddLogging();



// Para construir y ejecutar la aplicaci�n con las configuraciones definidas.
var app = builder.Build();

//habilitar los health checks 
app.MapHealthChecks("/health");

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

// Usar CORS Cross-Origin Resource Sharing
app.UseCors("CorsPolicy");

// Usar autenticaci�n y autorizaci�n
app.UseAuthentication();
app.UseAuthorization();

// Mapear controladores
app.MapControllers();

// Configurar health checks
//app.MapHealthChecks("/health");

app.Run();