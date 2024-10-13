using Library.Application.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Library.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Models.Book> Books => Set<Domain.Models.Book>();
    public DbSet<Domain.Models.Person> Person => Set<Domain.Models.Person>();
    public DbSet<Domain.Models.BookRental> BookRent => Set<Domain.Models.BookRental>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
