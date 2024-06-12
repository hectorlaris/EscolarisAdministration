using Microsoft.EntityFrameworkCore;

using ESC.AdministrationCore.Infraestructure;
using ESC.AdministrationCore.Infraestructure.Repositories.Implement; // To use IPackageRepository.
using ESC.AdministrationCore.Infraestructure.Repositories.Contracts; // To use IPackageRepository.
using ESC.AdministrationCore.Extensions;
using ESC.AdministrationCore.Application.Mapping;

using Microsoft.Data.SqlClient;

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

// registro  en el contenedor de inyección de dependencias
builder.Services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();

// Configurar CORS y Swagger utilizando los métodos de extensión
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