using Library.Application.Person.Queries.GetPerson;

namespace Library.API.Endpoints.Person;

// public record GetPersonRequest(PaginationRequest PaginationRequest);
public record GetPersonResponse(PaginationResult<PersonDto> PaginationResult);

public class GetPersonEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/person", async ([AsParameters] PaginationRequest PaginationRequest, ISender sender) =>
        {
            var result = await sender.Send(new GetPersonQuery(PaginationRequest));

            var response = result.Adapt<GetPersonResponse>();

            return Results.Ok(response);
        })
        .WithName("GetPerson")
        .Produces<GetPersonResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Processo para listar as pessoas com paginação")
        .WithDescription("Este endpoint retorna uma lista paginada de pessoas, a paginação deve ser informada no parametros.");
    }
}
