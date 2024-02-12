using Microsoft.EntityFrameworkCore;
using ResEvi.Contracts;
using ResEvi.Data.Entities;
using System.IO;
using System.Threading.Tasks;

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
            if(!optionsBuilder.IsConfigured)
            {
                Directory.CreateDirectory(App.DataDirectory);
                string dataSource = "Data Source=" + App.DatabaseFilePath;
                optionsBuilder.UseSqlite(dataSource);
            } 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AdvisorEntityTypeConfiguration().Configure(modelBuilder.Entity<Advisor>());
            new CompanyEntityTypeConfiguration().Configure(modelBuilder.Entity<Company>());
            new ContactEntityTypeConfiguration().Configure(modelBuilder.Entity<Contact>());
            new ProjectEntityTypeConfiguration().Configure(modelBuilder.Entity<Project>());
            new RecordEntityTypeConfiguration().Configure(modelBuilder.Entity<Record>());
        }

    }
}