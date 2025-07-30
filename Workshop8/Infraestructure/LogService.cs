using Microsoft.Data.Sqlite;

namespace Workshop8.Infrastructure
{
    public class LogService
    {
        public LogService(DbSelector dbSelector)
        {
            this.dbSelector = dbSelector;
            _connectionString = dbSelector.GetConnectionString();
        }

        private DbSelector dbSelector;
        private string _connectionString;

        public string GetMessage(string message)
        {
            return $@"origem = {dbSelector.GetProviderLabel()}
mensagem = {message}
momento = {DateTime.UtcNow.ToString("o")}";
        }

        public async Task<IEnumerable<string>> GetMessagesAsync(int PageNumber, int PageSize)
        {
            var clientes = new List<string>();
            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = DbSelector.PageQuery("select distinct Message FROM LogsLocal order by Id ");
                command.Parameters.AddWithValue("@PageSize", PageSize);
                command.Parameters.AddWithValue("@Offset", (PageNumber - 1) * PageSize);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        clientes.Add(reader.GetString(reader.GetOrdinal("Message")));
                    }
                }
            }
            return clientes;
        }

        public async Task WriteProviderLogAsync(string message)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = connection.CreateCommand();

                command.CommandText =
                    @"INSERT INTO LogsLocal (Message, CreatedAt) VALUES (@Message, @CreatedAt);
                  SELECT last_insert_rowid();";
                command.Parameters.AddWithValue("@Message", GetMessage(message));
                command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                await command.ExecuteScalarAsync();
            }
        }
    }
}