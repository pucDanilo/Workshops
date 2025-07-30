using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Workshop8.Models;

namespace Workshop8.Data
{
    public class SqliteClientRepository : IClientRepository
    {
        private readonly string _connectionString;

        public SqliteClientRepository(IConfiguration configuration)
        {
            var dbConfig = configuration.GetSection("Database");
            _connectionString = dbConfig.GetValue<bool>("UseRemote")
                ? dbConfig.GetValue<string>("Remote")
                : dbConfig.GetValue<string>("Local");
        }

        public async Task<IEnumerable<Cliente>> GetAllClientsAsync()
        {
            // TODO: implementar SELECT
            return new List<Cliente>();
        }

        public async Task AddClientAsync(Cliente c)
        {
            // TODO: implementar INSERT
        }

        public async Task UpdateClientAsync(Cliente c)
        {
            // TODO: implementar UPDATE
        }

        public async Task DeleteClientAsync(int id)
        {
            // TODO: implementar DELETE
        }
    }
}
