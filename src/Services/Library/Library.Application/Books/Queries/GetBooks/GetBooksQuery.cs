namespace Library.Application.Books.Queries.GetBooks;

public record GetBooksQuery(PaginationRequest PaginationRequest)
    : IQuery<GetBooksResult>;
public record GetBooksResult(PaginationResult<BookDto> Books);
