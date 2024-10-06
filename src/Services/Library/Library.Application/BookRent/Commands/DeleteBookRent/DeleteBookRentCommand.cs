using FluentValidation;

namespace Library.Application.BookRent.Commands.DeleteBookRent;

public record DeleteBookRentCommand(Guid BookRentalId) : ICommand<DeleteBookRentResult>;
public record DeleteBookRentResult(bool IsSuccess);

public class DeleteBookRentCommandValidator : AbstractValidator<DeleteBookRentCommand>
{
    public DeleteBookRentCommandValidator()
    {
        RuleFor(x => x.BookRentalId)
            .NotNull()
            .WithMessage("ID não informado.");
    }
}
