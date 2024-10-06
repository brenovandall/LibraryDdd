using Library.Domain.Models;
using Library.Domain.ValueObjects;

namespace Library.Application.BookRent.Commands.CreateBookRent;

public class CreateBookRentCommandHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateBookRentCommand, CreateBookRentResult>
{
    public async Task<CreateBookRentResult> Handle(CreateBookRentCommand command, CancellationToken cancellationToken)
    {
        var bookRent = CreateBookRental(command.BookRental);

        dbContext.BookRent.Add(bookRent);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateBookRentResult(bookRent.Id.Value);
    }

    private BookRental CreateBookRental(BookRentalDto bookRental)
    {
        return BookRental.Create(
            id: BookRentalId.Of(Guid.NewGuid()),
            bookId: BookId.Of(bookRental.BookId.Value),
            personId: PersonId.Of(bookRental.PersonId.Value),
            startDate: bookRental.StartDate,
            endDate: bookRental.EndDate,
            status: bookRental.Status);
    }
}
