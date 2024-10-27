
using Library.Application.Books.Commands.CreateBook;

namespace Library.API.Endpoints.Books;

public record CreateBooksRequest(BookDto BookDto);
public record CreateBooksResponse(Guid Id);

public class CreateBooksEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/books", async (CreateBooksRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateBookCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateBooksResponse>();

            return Results.Created("/person", response);
        })
        .WithName("CreateBooks")
        .Produces<CreateBooksResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Processo para criar um livro")
        .WithDescription("Este endpoint é usado para criar um novo livro.");
    }
}
