using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Workshop8.Models;

namespace Workshop8.Infrastructure
{
    public class LogService
    {
        public LogService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public async Task WriteProviderLogAsync(string message)
        {
            var useRemote = Configuration.GetValue<bool>("Database:UseRemote");
            var cstr = useRemote
                ? Configuration.GetConnectionString("Remote") ?? Configuration["Database:Remote"]
                : Configuration.GetConnectionString("Local") ?? Configuration["Database:Local"];

            var providerLabel = useRemote ? "REMOTO" : "LOCAL";

        }
    }
}
