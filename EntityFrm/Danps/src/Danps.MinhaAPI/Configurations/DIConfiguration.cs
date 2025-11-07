using Danps.My.Data;
using Danps.My.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Danps.MinhaAPI.Configurations
{
    public static class DIConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MyApplicationContext>();
            services.AddScoped<IMyClassRepository, MyClassRepository>();
            return services;
        }
    }
}