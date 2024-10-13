using Library.Domain.Models;

namespace Library.Application.Data;

public interface IApplicationDbContext
{
    DbSet<Book> Books { get; }
    DbSet<Domain.Models.Person> Person { get; }
    DbSet<BookRental> BookRent { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
