using Workshop8.Data;
using Workshop8.Infrastructure;
using Workshop8.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IClientRepository, SqliteClientRepository>();
builder.Services.AddSingleton<LogService>();
builder.Services.AddSingleton<DbSelector>();
var app = builder.Build();

await app.Services.GetRequiredService<DbSelector>().EnsureDatabasesAsync();

app.UseStaticFiles();
app.MapRazorPages();
await app.RunAsync();