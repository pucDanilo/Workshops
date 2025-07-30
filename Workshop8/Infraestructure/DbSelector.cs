using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Workshop8.Infrastructure
{
    public class DbSelector
    {
        private readonly IConfiguration _configuration;

        public DbSelector(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task EnsureDatabasesAsync()
        {
            // TODO: implementar lógica de criação de bancos (SQLite/local e remoto)
        }
    }
}
