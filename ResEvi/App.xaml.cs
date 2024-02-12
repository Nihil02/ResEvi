using Microsoft.Extensions.DependencyInjection;
using ResEvi.Data;
using System;
using System.IO;
using System.Windows;

namespace ResEvi
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static string? m_dataDirectory = null;

        public static string AppName => "ResEvi";

        public static string DatabaseFilePath => Path.Combine(DataDirectory, "database.db");

        public static string DataDirectory
        {
            get
            {
                if (m_dataDirectory == null)
                {
                    string dir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    m_dataDirectory = Path.Combine(dir, AppName);
                }

                return m_dataDirectory;
            }
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var services = new ServiceCollection();
            ConfigureServices(services);
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();
        }
    }
}
