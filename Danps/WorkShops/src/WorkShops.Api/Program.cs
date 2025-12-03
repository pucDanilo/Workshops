// Note: repository implementation removed for workshop exercise (TODOs in project files)

using WorkShops.Api;
using WorkShops.WebAPI.Core.Configuration;
using WorkShops.WebAPI.Core.Identity;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddLogger(builder.Configuration);

builder.Services.AddApiConfiguration(builder.Configuration);

builder.Services.AddJwtConfiguration(builder.Configuration);

builder.Services.AddSwaggerConfiguration();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

builder.Services.RegisterServices();


//builder.Services.AddMessageBusConfiguration(builder.Configuration);

var app = builder.Build();

DbMigrationHelpers.EnsureSeedData(app).Wait();

app.UseSwaggerConfiguration();

app.UseApiCoreConfiguration(app.Environment);

app.Run();

//builder.Services.AddMemoryCache();
//builder.Services.Configure<CacheSettings>(builder.Configuration.GetSection("Cache"));

//builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

// Depois expomos IWorkshopRepository como o "EF envelopado por cache"
/*builder.Services.AddScoped<IWorkshopRepository>(sp =>
    new CachedWorkshopRepository(
        sp.GetRequiredService<WorkshopRepository>(),
        sp.GetRequiredService<IMemoryCache>(),
        sp.GetRequiredService<IOptionsSnapshot<CacheSettings>>()));

// Exemplo de "captive dependency"
builder.Services.AddTransient<IPerRequestClock, PerRequestClock>(); // Transient
builder.Services.AddSingleton<ReportingSingleton>();

// Removendo para ativar o cached repository
// builder.Services.AddScoped<IWorkshopRepository, EfWorkshopRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
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

    o.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
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

// DI

var app = builder.Build();

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
            Detail = app.Environment.IsDevelopment() ? ex?.Message : null
        };

        context.Response.StatusCode = pd.Status.Value;
        context.Response.ContentType = "application/problem+json";
        await context.Response.WriteAsJsonAsync(pd);
    });
});

app.UseHttpsRedirection();

app.UseAuthentication();   // <-- antes
app.UseAuthorization();    // <-- depois

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CampusWorkshops API v1");
    c.RoutePrefix = "swagger"; // serve at /swagger
});

app.MapControllers();

app.Run();
*/