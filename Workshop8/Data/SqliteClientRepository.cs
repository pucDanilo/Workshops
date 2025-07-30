using Microsoft.Data.Sqlite;
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
            var clientes = new List<Cliente>();
            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT id, nome, email, criadoEm FROM Clientes;";
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        clientes.Add(new Cliente
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Nome = reader.GetString(reader.GetOrdinal("Nome")),
                            Email = reader.GetString(reader.GetOrdinal("Email"))
                            // Mapeie outras colunas aqui
                        });
                    }
                }
            }
            return clientes;
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