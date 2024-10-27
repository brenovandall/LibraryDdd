
using Library.Application.BookRent.Commands.DeleteBookRent;

namespace Library.API.Endpoints.BookRent;

public record DeleteBookRentRequest(Guid BookRentId);
public record DeleteBookRentResponse(bool IsSuccess);

public class DeleteBookRentEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/bookRents", async ([AsParameters] DeleteBookRentRequest request, ISender sender) =>
        {
            var command = request.Adapt<DeleteBookRentCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<DeleteBookRentResponse>();

            return Results.Created("/person", response);
        })
       .WithName("DeleteBookRent")
       .Produces<DeleteBookRentResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status404NotFound)
       .WithSummary("Processo para excluir um aluguel de livro")
       .WithDescription("Este endpoint é usado para excluir um aluguel de um livro.");
    }
}
