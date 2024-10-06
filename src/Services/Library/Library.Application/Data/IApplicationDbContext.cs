using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Data;

public interface IApplicationDbContext
{
    DbSet<Book> Books { get; }
    DbSet<Library.Domain.Models.Person> Person { get; }
    DbSet<BookRental> BookRent { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
