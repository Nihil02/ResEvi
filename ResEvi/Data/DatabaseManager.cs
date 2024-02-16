using ResEvi.Properties;
using System.Data.SQLite;

namespace ResEvi.Data
{
    internal static class DatabaseManager
    {
        public static SQLiteConnection CreateConnection()
        {
            var builder = new SQLiteConnectionStringBuilder
            {
                DataSource = App.DatabaseFile,
                PageSize = 4096,
                JournalMode = SQLiteJournalModeEnum.Wal,
                ForeignKeys = true,
            };

            return new SQLiteConnection(builder.ConnectionString);
        }

        public static async Task InitializeDatabaseAsync()
        {
            await using var db = CreateConnection();
            await db.OpenAsync();

            string[] queries = Resources.DatabaseSchema.Split(';', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            foreach (string sql in queries)
            {
                await using var command = db.CreateCommand();
                command.CommandText = sql;
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
