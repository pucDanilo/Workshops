using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Workshops.Infrastructure.Context;
using WorkShops.WebAPI.Core.Configuration;

namespace WorkShops.Api
{


    public static class ApiConfig
    {
        public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApiCoreConfiguration(configuration)
                .WithDbContext<WorkshopsDbContext>(configuration);
        }

        public static void UseApiConfiguration(this WebApplication app, IWebHostEnvironment env)
        {
            app.UseApiCoreConfiguration(env);
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }

    public static class Class
    { 

        public static void SetAuthentication(this IServiceCollection services, ConfigurationManager configuration)
        {
            var jwt = configuration.GetSection("JwtSettings");
            var keyBytes = Encoding.UTF8.GetBytes(jwt["Key"]!);
            var Issuer = jwt["Issuer"];
            var Audience = jwt["Audience"];
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = new()
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateIssuerSigningKey = true,
                      ValidIssuer = Issuer,
                      ValidAudience = Audience,
                      IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
                      ClockSkew = TimeSpan.FromMinutes(1)
                  };
              });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanWriteWorkshops", p => p.RequireRole("Instructor", "Admin"));
                options.AddPolicy("CanDeleteWorkshops", p => p.RequireRole("Admin"));
                options.AddPolicy("CanViewAnalytics", p => p.RequireRole("Admin"));
            });
        }
    }
}