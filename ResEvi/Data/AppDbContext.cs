using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using ResEvi.Data.Entities;
using System.IO;

namespace ResEvi.Data
{
    internal sealed class AppDbContext: DbContext
    {
        public AppDbContext() : base()
        {
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Advisor> Advisors {get; set;}

        public DbSet<Company> Companies {get; set;}

        public DbSet<Contact> Contacts {get; set;}

        public DbSet<Project> Projects {get; set;}

        public DbSet<Record> Records {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                Directory.CreateDirectory(App.DataDirectory);
                var builder = new SqliteConnectionStringBuilder
                {
                    DataSource = App.DatabaseFilePath,
                    ForeignKeys = true,
                };

                optionsBuilder.UseSqlite(builder.ConnectionString);
            } 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(App).Assembly);
        }
    }
}
