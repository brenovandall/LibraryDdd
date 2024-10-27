using Library.Application.BookRent.Queries.GetBookRentsByBookId;

namespace Library.API.Endpoints.BookRent;

// public record GetBookRentByIdRequest(Guid Id);
public record GetBookRentByIdResponse(IEnumerable<BookRentalDto> BookRents);

public class GetBookRentByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/bookRents/{Id}", async ([AsParameters] Guid Id, ISender sender) =>
        {
            var result = await sender.Send(new GetBookRentsByBookIdQuery(Id));

            var response = result.Adapt<GetBookRentByIdResponse>();

            return Results.Ok(response);
        })
        .WithName("GetBookRentById")
        .Produces<GetBookRentByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Processo para listar aluguéis pelo ID do livro")
        .WithDescription("Este endpoint é usado para retornar uma listagem dos aluguéis pelo ID do livro informado no parâmetro.");
    }
}
