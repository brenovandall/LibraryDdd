namespace Library.Application.Person.Queries.GetPerson;

public class GetPersonQueryHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetPersonQuery, GetPersonResult>
{
    public async Task<GetPersonResult> Handle(GetPersonQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;
        var searchString = query.PaginationRequest.SearchString;

        var personQuery = dbContext.Person.AsQueryable();

        if (!string.IsNullOrEmpty(searchString))
        {
            personQuery = personQuery
                .Where(x => EF.Functions.Like(x.Name.ToLower(), $"%{searchString.ToLower()}%"));
        }

        var person = await personQuery
            .OrderBy(x => x.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        var count = await dbContext.Person.LongCountAsync(cancellationToken);

        return new GetPersonResult(
            new PaginationResult<PersonDto>(
                pageIndex,
                pageSize,
                count,
                person.ToPersonDtoList())
            );
    }
}
