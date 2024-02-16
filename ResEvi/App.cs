namespace ResEvi
{
    internal sealed class App
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
        public static string ArchiveDirectory
        {
            get
            {
                return Path.Combine(DataDirectory, "Archive");
            }
        }

        /// <summary>
        /// Gets the full path of the main SQLite database file.
        /// </summary>
        public static string DatabaseFile
        {
            get
            {
                return Path.Combine(DataDirectory, "database.db");
            }
        }
    }
}
