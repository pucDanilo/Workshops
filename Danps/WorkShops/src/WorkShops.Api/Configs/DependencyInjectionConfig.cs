using Workshops.Api.Repositories;
using Workshops.Api.Services;
using Workshops.Domain.Repository;
using Workshops.Infrastructure.Context;
using WorkShops.Domain.Services;
using WorkShops.WebAPI.Core.User;

namespace WorkShops.Api
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // API
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            // Lifetimes de exemplo
            services.AddTransient<IRequestIdTransient, RequestIdTransient>();
            services.AddScoped<IRequestIdScoped, RequestIdScoped>();
            services.AddSingleton<IRequestIdSingleton, RequestIdSingleton>();
            services.AddTransient<IAuthService, AuthService>();


            // Application
            //services.AddScoped<IMediatorHandler, MediatorHandler>();
            //services.AddScoped<IVoucherQueries, VoucherQueries>();
            //services.AddScoped<IOrderQueries, OrderQueries>();

            // Date
            services.AddScoped<IWorkshopRepository, WorkshopRepository>();
            //services.AddScoped<IVoucherRepository, VoucherRepository>();
            services.AddScoped<WorkshopsDbContext>();

        }
    }
}