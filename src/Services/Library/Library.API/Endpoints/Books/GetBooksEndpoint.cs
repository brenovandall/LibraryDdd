
using Library.Application.Books.Queries.GetBooks;

namespace Library.API.Endpoints.Books;

// public record GetBooksRequest(PaginationRequest PaginationRequest);
public record GetBooksResponse(PaginationResult<BookDto> PaginationResult);

public class GetBooksEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/books", async ([AsParameters] PaginationRequest PaginationRequest, ISender sender) =>
        {
            var result = await sender.Send(new GetBooksQuery(PaginationRequest));

            var response = result.Adapt<GetBooksResponse>();

            return Results.Ok(response);
        })
        .WithName("GetBooks")
        .Produces<GetBooksResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Processo para listar as livros com paginação")
        .WithDescription("Este endpoint retorna uma lista paginada de livros, a paginação deve ser informada no parametros.");
    }
}
