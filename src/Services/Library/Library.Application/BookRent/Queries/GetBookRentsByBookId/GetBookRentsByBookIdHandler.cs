using Library.Domain.ValueObjects;

namespace Library.Application.BookRent.Queries.GetBookRentsByBookId;

public class GetBookRentsByBookIdHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetBookRentsByBookIdQuery, GetBookRentsByBookIdResult>
{
    public async Task<GetBookRentsByBookIdResult> Handle(GetBookRentsByBookIdQuery query, CancellationToken cancellationToken)
    {
        var bookRents = await dbContext.BookRent
            .Include(x => x.BookId)
            .Include(x => x.PersonId)
            .AsNoTracking()
            .Where(x => x.BookId == BookId.Of(query.BookId))
            .ToListAsync();

        return new GetBookRentsByBookIdResult(bookRents.ToBookRentalDtoList());
    }
}
