using Workshops.Infrastructure.Context;
using Danps.WebAPI.Core.Configuration;

namespace WorkShops.Api;

public static class ApiConfig
{
    public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApiCoreConfiguration(configuration)
            .WithDbContext<WorkshopsDbContext>(configuration);

        services.AddAuthorization(options =>
        {
            options.AddPolicy("CanWriteWorkshops", p => p.RequireRole("Instructor", "Admin"));
            options.AddPolicy("CanDeleteWorkshops", p => p.RequireRole("Admin"));
            options.AddPolicy("CanViewAnalytics", p => p.RequireRole("Admin"));
        });
    }

    public static void UseApiConfiguration(this WebApplication app, IWebHostEnvironment env)
    {
        app.UseApiCoreConfiguration(env);
        app.UseAuthentication();
        app.UseAuthorization();
    }
}