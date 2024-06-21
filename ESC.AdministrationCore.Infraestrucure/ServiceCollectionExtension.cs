using ESC.AdministrationCore.Application.Interfaces;
using ESC.AdministrationCore.Infraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;

namespace ESC.AdministrationCore.Infraestructure
{
    // Se extiende IServiceCollection para registrar servicios que serán utilizados en
    // la inyección de dependencias
    // Para gestionar correctamente el ciclo de vida de los servicios y recursos en la aplicación ASP.Net Core.
    public static class ServiceCollectionExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Tiempo de Vida: Transitorio (Transient)
            // AddTransient crea una nueva instancia del servicio cada vez que se solicita
            // Descripción: Una instancia del servicio es creada una vez por cada solicitud HTTP y
            // se comparte dentro de esa misma solicitud. Si el servicio se solicita varias veces durante una solicitud HTTP, se usará la misma instancia.

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // Scoped: porque durante una solicitud HTTP puede ser necesario
            // AddScoped crea una instancia del servicio por solicitud HTTP y reutiliza la misma instancia durante la misma solicitud.
            // acceder a la misma instancia del repositorio para garantizar consistencia en las
            // operaciones de base de datos.
            services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();


        }
    }
}