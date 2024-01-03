using Microsoft.EntityFrameworkCore;
using ResEvi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResEvi.Contracts
{
    internal interface IDbContext : IAsyncDisposable, IDisposable, Microsoft.EntityFrameworkCore.Infrastructure.IInfrastructure<IServiceProvider>, Microsoft.EntityFrameworkCore.Internal.IDbContextDependencies, Microsoft.EntityFrameworkCore.Internal.IDbContextPoolable, Microsoft.EntityFrameworkCore.Internal.IDbSetCache
    {
        DbSet<Advisor> Advisors { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<Record> Records { get; set; }

        Task<int> SaveChangesAsync();
    }
}
