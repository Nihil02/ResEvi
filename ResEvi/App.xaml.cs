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
        private static string? _localDataDirectory = null;

        public static string AppName => "ResEvi";

        public static string DatabaseFilePath => Path.Combine(LocalDataDirectory, "database.db");

        public static string LocalDataDirectory
        {
            get
            {
                if (_localDataDirectory == null)
                {
                    string dir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    _localDataDirectory = Path.Combine(dir, AppName);
                }

                return _localDataDirectory;
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
