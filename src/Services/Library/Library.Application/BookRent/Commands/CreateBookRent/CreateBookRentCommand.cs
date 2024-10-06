using FluentValidation;

namespace Library.Application.BookRent.Commands.CreateBookRent;

public record CreateBookRentCommand(BookRentalDto BookRental) : ICommand<CreateBookRentResult>;
public record CreateBookRentResult(Guid Id);

public class CreateBookRentCommandValidator : AbstractValidator<CreateBookRentCommand>
{
    public CreateBookRentCommandValidator()
    {
        RuleFor(x => x.BookRental.BookId)
            .NotNull()
            .WithMessage("ID do livro não informado.");

        RuleFor(x => x.BookRental.PersonId)
            .NotNull()
            .WithMessage("ID da pessoa não informado.");

        RuleFor(x => x.BookRental.StartDate)
            .NotNull()
            .WithMessage("Data de início não informada.");

        RuleFor(x => x.BookRental.Status)
            .NotNull()
            .WithMessage("Status não informado.");
    }
}
