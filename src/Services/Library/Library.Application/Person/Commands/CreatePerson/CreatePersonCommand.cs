using FluentValidation;

namespace Library.Application.Person.Commands.CreatePerson;

public record CreatePersonCommand(PersonDto Person) : ICommand<CreatePersonResult>;
public record CreatePersonResult(Guid Id);

public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
{
    public CreatePersonCommandValidator()
    {
        RuleFor(x => x.Person.Name)
            .NotNull()
            .WithMessage("Nome não informado.");

        RuleFor(x => x.Person.Cpf)
            .NotNull()
            .WithMessage("CPF não informado.");
    }
}
