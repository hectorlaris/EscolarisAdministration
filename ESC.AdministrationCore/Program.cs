using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Serilog;

using ESC.AdministrationCore.Application.Mapping;
using ESC.AdministrationCore.Infraestructure;
using ESC.AdministrationCore.Extensions;
using ESC.AdministrationCore.Helper;


// Constructor de la aplicación web
// para preparar y configurarla 
var builder = WebApplication.CreateBuilder(args);

// Configuración conexion a la base de datos usando secrets
builder.Services.AddDbContext<AdministrationCoreDbContext>(options =>
{ 
    var conStrBuilder = new SqlConnectionStringBuilder(
                          builder.Configuration.GetConnectionString("Escolaris"));

    conStrBuilder.Password = builder.Configuration["SQL_PASSWORD"];

    options.UseSqlServer(builder.Configuration.GetConnectionString("EscolarisAdmon"));

    //var connection = conStrBuilder.ConnectionString;

});

// Register the caching service in the application’s service container To enable in-memory caching.
builder.Services.AddMemoryCache();

// Métodos de extensión para configrar servicios específicos de la app
// Register the IDocumentTypeRepository with its implementation DocumentTypeRepository
//builder.Services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
builder.Services.RegisterServices();

// configure strongly typed settings object  20240620
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// CORS Cross-Origin Resource Sharing permite que los recursos en un servidor web sean solicitados desde otro dominio distinto al propio dominio del servidor
// Swagger utilizando los métodos de extensión
builder.Services.ConfigureCors();
builder.Services.ConfigureSwagger();

//AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Agregar servicios de controladores MVC
builder.Services.AddControllers();

// monitorear la salud de tu aplicación
builder.Services.AddHealthChecks();

// manejo de logs para facilitar la depuración y monitoreo de la aplicación
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole();
    loggingBuilder.AddDebug();
});

// Configuración de Serilog para  ver los mensajes de  _logger.LogInformation(...
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/csi-esc-administration-core.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// Configuración de servicios
builder.Services.AddLogging();

//sets the Redis server’s connection string to “localhost”, indicating that the Redis server is running on the local machine.
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost";
    options.ConfigurationOptions = new StackExchange.Redis.ConfigurationOptions()
    {
        AbortOnConnectFail = true,
        EndPoints = { options.Configuration }
    };
});


// Para construir y ejecutar la aplicación con las configuraciones definidas.
var app = builder.Build();

//habilitar los health checks 
app.MapHealthChecks("/health");

// Configuración del pipeline de solicitudes HTTP
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

// custom jwt auth middleware
app.UseMiddleware<JwtMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Usar CORS Cross-Origin Resource Sharing
app.UseCors("CorsPolicy");

// Usar autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();

// Mapear controladores
app.MapControllers();

// Configurar health checks
//app.MapHealthChecks("/health");

app.Run();