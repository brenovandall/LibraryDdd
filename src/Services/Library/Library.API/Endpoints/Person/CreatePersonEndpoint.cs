
using Library.Application.Person.Commands.CreatePerson;

namespace Library.API.Endpoints.Person;

public record CreatePersonRequest(PersonDto PersonDto);
public record CreatePersonResponse(Guid Id);

public class CreatePersonEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/person", async (CreatePersonRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreatePersonCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreatePersonResponse>(); 

            return Results.Created("/person", response);
        })
        .WithName("CreatePerson")
        .Produces<GetPersonResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Processo para criar uma pessoa")
        .WithDescription("Este endpoint é usado para criar uma nova pessoa.");
    }
}
