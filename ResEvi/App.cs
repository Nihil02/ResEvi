using ResEvi.Data;

namespace ResEvi
{
    internal static class App
    {
        private static string? m_dataDirectory = null;

        /// <summary>
        /// Gets the full path of the application's data directory.
        /// </summary>
        public static string DataDirectory
        {
            get
            {
                if (m_dataDirectory == null)
                {
                    string directory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    m_dataDirectory = Path.Combine(directory, "ITCM");
                }

                return m_dataDirectory;
            }
        }

        /// <summary>
        /// Gets the full path of the archive directory root.
        /// </summary>
        public static string ArchiveDirectory => Path.Combine(DataDirectory, "Archive");

        /// <summary>
        /// Gets the full path of the main SQLite database file.
        /// </summary>
        public static string DatabaseFile => Path.Combine(DataDirectory, "database.db");

        /// <summary>
        /// Executes the startup sequence for the application.
        /// </summary
        public static async Task StartupAsync()
        {
            bool initialize_db = false;

            if (!Directory.Exists(DataDirectory))
            {
                Directory.CreateDirectory(DataDirectory);
                Directory.CreateDirectory(ArchiveDirectory);
                initialize_db = true;
            }

            if (initialize_db || !File.Exists(DatabaseFile))
            {
                await DatabaseManager.InitializeDatabaseAsync();
            }
        }
    }
}
