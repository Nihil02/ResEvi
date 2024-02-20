using System.Data.SQLite;

namespace ResEvi.Data;

public sealed class AppDbContext : IAsyncDisposable, IDisposable
{
    private readonly SQLiteConnection m_db;

    public AppDbContext()
    {
        m_db = DatabaseManager.CreateConnection();
    }

    public async ValueTask DisposeAsync()
    {
        await m_db.DisposeAsync();
    }

    public void Dispose()
    {
        m_db.Dispose();
    }
}
