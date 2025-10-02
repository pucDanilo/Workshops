using Microsoft.OpenApi.Models;

namespace Workshop10_API.Api.Configurations
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "CampusWorkshops API",
                    Version = "v1",
                    Description = "API para gestão de workshops do campus (MVP in-memory)."
                });
                var bearerScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Cole apenas o JWT (sem 'Bearer ').",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,   // <- IMPORTANTE
                    Scheme = "bearer",                // <- minúsculo
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference   // <- garante que o requirement aponte para esta definição
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                o.AddSecurityDefinition("Bearer", bearerScheme);

                o.AddSecurityRequirement(new OpenApiSecurityRequirement{
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
                });
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CampusWorkshops API v1");
                c.RoutePrefix = "swagger"; // serve at /swagger
            });
        }
    }
}