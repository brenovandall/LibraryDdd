using Library.Application.BookRent.Commands.UpdateBookRent;

namespace Library.API.Endpoints.BookRent;

public record UpdateBookRentRequest(BookRentalDto BookRentalDto);
public record UpdateBookRentResponse(bool IsSuccess);

public class UpdateBookRentEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/bookRents", async (UpdateBookRentRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateBookRentCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateBookRentResponse>();

            return Results.Ok(response);
        })
       .WithName("UpdateBookRent")
       .Produces<UpdateBookRentResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status404NotFound)
       .WithSummary("Processo para editar um aluguel de livro")
       .WithDescription("Este endpoint é usado para editar um aluguel de um livro existente.");
    }
}
