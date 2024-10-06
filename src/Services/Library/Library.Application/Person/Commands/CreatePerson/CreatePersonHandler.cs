using Library.Domain.ValueObjects;

namespace Library.Application.Person.Commands.CreatePerson;

public class CreatePersonCommandHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreatePersonCommand, CreatePersonResult>
{
    public async Task<CreatePersonResult> Handle(CreatePersonCommand command, CancellationToken cancellationToken)
    {
        var person = CreatePerson(command.Person);

        dbContext.Person.Add(person);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreatePersonResult(person.Id.Value);
    }

    private Domain.Models.Person CreatePerson(PersonDto personDto)
    {
        return Domain.Models.Person.Create(
            id: PersonId.Of(Guid.NewGuid()),
            name: personDto.Name,
            cpf: personDto.Cpf,
            birthDate: personDto.BirthDate);
    }
}
