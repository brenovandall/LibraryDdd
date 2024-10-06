using Library.Application.Data;
using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Library.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Book> Books => Set<Book>();
    public DbSet<Library.Domain.Models.Person> Person => Set<Person>();
    public DbSet<BookRental> BookRent => Set<BookRental>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
