using Workshop10_API.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApiConfiguration(builder.Configuration);
builder.Services.RegisterServices(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();
app.UseApiConfiguration(app.Environment);
app.UseSwaggerConfiguration();
app.MapControllers();

app.Run();