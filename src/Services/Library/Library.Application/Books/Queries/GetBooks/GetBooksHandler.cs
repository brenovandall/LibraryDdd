
namespace Library.Application.Books.Queries.GetBooks;

public class GetBooksQueryHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetBooksQuery, GetBooksResult>
{
    public async Task<GetBooksResult> Handle(GetBooksQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;
        var searchString = query.PaginationRequest.SearchString;

        var booksQuery = dbContext.Books.AsQueryable();

        if (!string.IsNullOrEmpty(searchString))
        {
            booksQuery = booksQuery
                .Where(x => EF.Functions.Like(x.Name.ToLower(), $"%{searchString.ToString()}%"));
        }

        var books = await booksQuery
            .OrderBy(x => x.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        var count = await dbContext.Books.LongCountAsync(cancellationToken);

        return new GetBooksResult(
            new PaginationResult<BookDto>(
                pageIndex,
                pageSize,
                count,
                books.ToBookDtoList())
            );
    }
}
