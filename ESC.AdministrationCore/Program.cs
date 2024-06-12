using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

using ESC.AdministrationCore.Infraestructure;
using ESC.AdministrationCore.Infraestructure.Repositories.Implement; // To use IPackageRepository.
using ESC.AdministrationCore.Infraestructure.Repositories.Contracts; // To use IPackageRepository.
using ESC.AdministrationCore.Extensions;
using ESC.AdministrationCore.Application.Mapping;


// Constructor de la aplicaci�n web
// para preparar y configurarla 
var builder = WebApplication.CreateBuilder(args);


// Configuraci�n de la base de datos
builder.Services.AddDbContext<AdministrationCoreDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EscolarisAdmon"));
});

// registro  en el contenedor de inyecci�n de dependencias
builder.Services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();

// Configurar CORS y Swagger utilizando los m�todos de extensi�n
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