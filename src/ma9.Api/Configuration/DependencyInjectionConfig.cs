using ma9.Business.Interfaces;
using ma9.Business.Notificacoes;
using ma9.Business.Services;
using ma9.Data.Context;
using ma9.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ma9.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolverDependencias(this IServiceCollection services)
        {
            services.AddScoped<ModelsContext>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IContatoService, ContatoService>();
            services.AddScoped<INotificador, Notificador>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
