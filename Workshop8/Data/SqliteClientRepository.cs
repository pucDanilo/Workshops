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
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            CriadoEm = reader.GetDateTime(reader.GetOrdinal("criadoEm"))
                        });
                    }
                }
            }
            return clientes;
        }

        public async Task AddClientAsync(Cliente c)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"INSERT INTO Clientes (Nome, Email, criadoEm) VALUES (@Nome, @Email, @criadoEm);
                  SELECT last_insert_rowid();"; 
                command.Parameters.AddWithValue("@Nome", c.Nome);
                command.Parameters.AddWithValue("@Email", c.Email);
                command.Parameters.AddWithValue("@criadoEm", DateTime.Now);
                c.Id = (int)(long)await command.ExecuteScalarAsync(); 
            }
        }

        public async Task UpdateClientAsync(Cliente c)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText =
                    "UPDATE Clientes SET Nome = @Nome, Email = @Email WHERE Id = @Id;";
                command.Parameters.AddWithValue("@Nome", c.Nome);
                command.Parameters.AddWithValue("@Email", c.Email);
                command.Parameters.AddWithValue("@Id", c.Id);

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteClientAsync(int id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Clientes WHERE Id = @Id;";
                command.Parameters.AddWithValue("@Id", id);

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}