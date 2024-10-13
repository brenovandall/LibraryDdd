using Library.Application.Dtos;
using Library.Application.Person.Commands.CreatePerson;
using MediatR;

namespace Library.Application.Tests.Person.Commands;

public class CreatePersonEndpointHandlerTests(ISender sender)
{
    [Fact]
    public async Task Deve_RetornarSucesso_QuandoPersonDtoForValido()
    {
        var id = Guid.NewGuid();
        var name = "Breno Van Dall";
        var cpf = "10638013940";
        var birthDate = new DateTime(2006, 5, 3);

        var personDto = new PersonDto(
            id,
            name,
            cpf,
            birthDate);

        var command = new CreatePersonCommand(personDto);

        var result = await sender.Send(command);

        Assert.Equal(result, new CreatePersonResult(id));
    }
}
