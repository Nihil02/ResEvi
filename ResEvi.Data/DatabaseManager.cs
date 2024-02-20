using ResEvi.Data.Properties;
using System.Data.SQLite;

namespace ResEvi.Data;

internal static class DatabaseManager
{
    public static SQLiteConnection CreateConnection()
    {
        var builder = new SQLiteConnectionStringBuilder
        {
            // TODO: FIX THIS
            //DataSource = App.DatabaseFile,
            PageSize = 4096,
            JournalMode = SQLiteJournalModeEnum.Wal,
            ForeignKeys = true,
        };

        var db = new SQLiteConnection();
        db.Open();
        return db;
    }

    public static async Task<SQLiteConnection> CreateConnectionAsync()
    {
        var builder = new SQLiteConnectionStringBuilder
        {
            //TODO: FIX THIS
            //DataSource = App.DatabaseFile,
            PageSize = 4096,
            JournalMode = SQLiteJournalModeEnum.Wal,
            ForeignKeys = true,
        };

        var db = new SQLiteConnection(builder.ConnectionString);
        await db.OpenAsync();
        return db;
    }

    public static async Task InitializeDatabaseAsync()
    {
        await using var db = await CreateConnectionAsync();
        string[] queries = Resources.DatabaseSchema.Split(';', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        foreach (string sql in queries)
        {
            await using var command = db.CreateCommand();
            command.CommandText = sql;
            await command.ExecuteNonQueryAsync();
        }
    }
}
