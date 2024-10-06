using FluentValidation;

namespace Library.Application.BookRent.Commands.UpdateBookRent;

public record UpdateBookRentCommand(BookRentalDto BookRental) : ICommand<UpdateBookRentResult>;
public record UpdateBookRentResult(bool IsSuccess);

public class UpdateBookRentCommandValidator : AbstractValidator<UpdateBookRentCommand>
{
    public UpdateBookRentCommandValidator()
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
