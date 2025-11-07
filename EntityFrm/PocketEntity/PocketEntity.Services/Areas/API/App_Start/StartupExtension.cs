
using Microsoft.Extensions.DependencyInjection;
using PocketEntity.Core.Services;

namespace PocketEntity.Core
{
    public static class StartupExtension
    {
        public static void AddDanpsService(this IServiceCollection services)
        { 
            services.AddTransient<IContraChequeService, ContraChequeService>(); 
            services.AddTransient<IPregaoService, PregaoService>();
            services.AddTransient<IProtocoloService, ProtocoloService>();
            services.AddTransient<IStockService, StockService>(); 
            services.AddTransient<ITenantService, TenantService>();
            services.AddTransient<ITituloService, TituloService>(); 
        }
    }
}