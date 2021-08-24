using ma9.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ma9.Api.Configuration
{
    public static class DatabaseConfig
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ModelsContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ModelsContext"));
            });

            return services;
        }
    }
}
