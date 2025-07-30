using Microsoft.Data.Sqlite;

namespace Workshop8.Infrastructure
{
    public class DbSelector
    {
        private readonly bool useRemote;
        private readonly string _connectionString;
        private readonly string _providerLabel;

        public DbSelector(IConfiguration configuration)
        {
            useRemote = configuration.GetValue<bool>("Database:UseRemote");
            _connectionString = useRemote
                ? configuration.GetConnectionString("Remote") ?? configuration["Database:Remote"]
                : configuration.GetConnectionString("Local") ?? configuration["Database:Local"];

            _providerLabel = useRemote ? "REMOTO" : "LOCAL";
        }

        public string GetConnectionString() => _connectionString;

        public string GetProviderLabel() => _providerLabel;

        public bool GetUseRemote() => useRemote;

        private async Task<bool> VerificarTabelaExistenteAsync()
        {
            try
            {
                await PerformValidationQueriesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private async Task PerformValidationQueriesAsync()
        {
            int clientCount = 0;
            int logCount = 0;

            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.OpenAsync();
                var clientCommand = connection.CreateCommand();
                clientCommand.CommandText = "SELECT COUNT(*) FROM Clientes;";
                clientCount = Convert.ToInt32(await clientCommand.ExecuteScalarAsync());

                var logCommand = connection.CreateCommand();
                logCommand.CommandText = "SELECT COUNT(*) FROM LogsLocal;";
                logCount = Convert.ToInt32(await logCommand.ExecuteScalarAsync());
            }

            Console.WriteLine($"Provider ativo = {_providerLabel}; clientes = {clientCount}; logs = {logCount}");
        }

        public async Task EnsureDatabasesAsync()
        {
            bool OK = await VerificarTabelaExistenteAsync();

            if (!OK)
            {
                await InitializeSqliteDatabaseAsync();
            }
            await PerformValidationQueriesAsync();
        }

        private async Task InitializeSqliteDatabaseAsync()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = $@"
CREATE TABLE IF NOT EXISTS Clientes (
  Id INTEGER PRIMARY KEY AUTOINCREMENT,
  Nome TEXT NOT NULL,
  Email TEXT NOT NULL,
  CriadoEm DATETIME NOT NULL
);

CREATE TABLE IF NOT EXISTS LogsLocal (
  Id INTEGER PRIMARY KEY AUTOINCREMENT,
  Message TEXT NOT NULL,
  CreatedAt DATETIME NOT NULL
);

INSERT INTO Clientes (Nome, Email, CriadoEm)
  VALUES ('Exemplo Cliente  ${_providerLabel}', 'exemplo@dominio.com', datetime('now'));
;";
                await command.ExecuteNonQueryAsync();
                Console.WriteLine("Tabela 'Clientes' verificada/criada no SQLite.");
            }
        }

        public static string PageQuery(string _querySpecification) => $" {_querySpecification} LIMIT @PageSize OFFSET @Offset;";
    }
}