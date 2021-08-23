using ma9.Business.Interfaces;
using ma9.Business.Services;
using ma9.Data.Context;
using ma9.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ma9.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolverDependencias(this IServiceCollection services)
        {
            services.AddScoped<ModelsContext>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();

            return services;
        }
    }
}
