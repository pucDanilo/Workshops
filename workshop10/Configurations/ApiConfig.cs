using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Workshop10_API.Api.Infrastructure.Data;

namespace Workshop10_API.Api.Configurations
{
    public static class ApiConfig
    {
        public static void UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment environment)
        {
            // Exception handler that returns RFC7807 ProblemDetails for unhandled errors
            app.UseExceptionHandler(errApp =>
            {
                errApp.Run(async context =>
                {
                    var feature = context.Features.Get<IExceptionHandlerFeature>();
                    var ex = feature?.Error;

                    var pd = new ProblemDetails
                    {
                        Title = "An unexpected error occurred.",
                        Status = StatusCodes.Status500InternalServerError,
                        Detail = environment.IsDevelopment() ? ex?.Message : null
                    };

                    context.Response.StatusCode = pd.Status.Value;
                    context.Response.ContentType = "application/problem+json";
                    await context.Response.WriteAsJsonAsync(pd);
                });
            });

            app.UseHttpsRedirection();

            app.UseAuthentication();   // <-- antes
            app.UseAuthorization();    // <-- depois
        }

        public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            // JWT
            var jwt = configuration.GetSection("Jwt");
            var keyBytes = Encoding.UTF8.GetBytes(jwt["Key"]!);

            services
              .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = new()
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateIssuerSigningKey = true,
                      ValidIssuer = jwt["Issuer"],
                      ValidAudience = jwt["Audience"],
                      IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
                      ClockSkew = TimeSpan.FromMinutes(1) // previsível para testes
                  };
              });

            services.AddAuthorization();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanWriteWorkshops", p => p.RequireRole("Instructor", "Admin"));
                options.AddPolicy("CanDeleteWorkshops", p => p.RequireRole("Admin"));
                options.AddPolicy("CanViewAnalytics", p => p.RequireRole("Admin"));
            });

            // Add services
            services.AddDbContext<WorkshopsDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("WorkshopsDb")));
        }
    }
}