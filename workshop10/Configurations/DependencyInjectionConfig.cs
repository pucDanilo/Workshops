using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Workshop10_API.Api.Repositories;
using Workshop10_API.Api.Services;

namespace Workshop10_API.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Lifetimes de exemplo
            services.AddTransient<IRequestIdTransient, RequestIdTransient>();
            services.AddScoped<IRequestIdScoped, RequestIdScoped>();
            services.AddSingleton<IRequestIdSingleton, RequestIdSingleton>();

            // Exemplo de "captive dependency"
            services.AddTransient<IPerRequestClock, PerRequestClock>(); // Transient
            services.AddSingleton<ReportingSingleton>();

            var cache = configuration.GetSection("Cache");
            if (cache != null)
            {
                services.AddMemoryCache();
                services.Configure<CacheSettings>(configuration.GetSection("Cache"));
                services.RegisterRepositoryCache();
            }
            else
                services.RegisterRepository();
        }

        public static void RegisterRepositoryCache(this IServiceCollection services)
        {
            // Primeiro registramos a implementação EF concreta
            services.AddScoped<EfWorkshopRepository>();

            // Depois expomos IWorkshopRepository como o "EF envelopado por cache"
            services.AddScoped<IWorkshopRepository>(sp =>
                new CachedWorkshopRepository(
                    sp.GetRequiredService<EfWorkshopRepository>(),
                    sp.GetRequiredService<IMemoryCache>(),
                    sp.GetRequiredService<IOptionsSnapshot<CacheSettings>>()));
        }

        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped<IWorkshopRepository, EfWorkshopRepository>();
        }
    }
}