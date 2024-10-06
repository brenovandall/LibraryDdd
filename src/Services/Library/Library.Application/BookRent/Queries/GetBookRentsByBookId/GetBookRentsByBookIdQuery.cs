namespace Library.Application.BookRent.Queries.GetBookRentsByBookId;

public record GetBookRentsByBookIdQuery(Guid BookId) : IQuery<GetBookRentsByBookIdResult>;
public record GetBookRentsByBookIdResult(IEnumerable<BookRentalDto> BookRents);
