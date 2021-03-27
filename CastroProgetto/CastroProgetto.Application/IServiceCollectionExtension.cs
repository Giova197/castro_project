using CastroProgetto.Application.Services;
using CastroProgetto.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace CastroProgetto.Application
{
    public static class IServiceCollectionExtension
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddPersistence();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
