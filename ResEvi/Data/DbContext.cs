using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace ResEvi.Data.Entities
{
    internal sealed class AppDbContext: DbContext 
    {
        public DbSet<Advisor> Advisors {get; set;}
        public DbSet<Company> Companies {get; set;}
        public DbSet<Contact> Contacts {get; set;}
        public DbSet<Project> Projects {get; set;}
        public DbSet<Record> Records {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Directory.CreateDirectory(App.LocalDataDirectory);
            string dataSource = "Data Source=" + App.DatabaseFilePath;
            optionsBuilder.UseSqlite(dataSource);
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