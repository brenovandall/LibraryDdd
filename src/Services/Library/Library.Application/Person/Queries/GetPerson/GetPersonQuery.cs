using Library.Application.Dtos;

namespace Library.Application.Person.Queries.GetPerson;

public record GetPersonQuery(PaginationRequest PaginationRequest)
    : IQuery<GetPersonResult>;
public record GetPersonResult(PaginationResult<PersonDto> PaginationResult);
