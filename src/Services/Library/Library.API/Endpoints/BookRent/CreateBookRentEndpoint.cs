
using Library.Application.BookRent.Commands.CreateBookRent;

namespace Library.API.Endpoints.BookRent;

public record CreateBookRentRequest(BookRentalDto BookRentalDto);
public record CreateBookRentResponse(Guid Id);

public class CreateBookRentEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/bookRents", async (CreateBookRentRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateBookRentCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateBookRentResponse>();

            return Results.Created("/person", response);
        })
       .WithName("CreateBookRent")
       .Produces<CreateBookRentResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status404NotFound)
       .WithSummary("Processo para criar um aluguel de livro")
       .WithDescription("Este endpoint é usado para criar um novo aluguel de um livro.");
    }
}
