
using BuildingBlocks.Exceptions;
using Library.Domain.Models;
using Library.Domain.ValueObjects;

namespace Library.Application.BookRent.Commands.UpdateBookRent;

public class UpdateBookRentCommandHandler(IApplicationDbContext dbContext)
    : ICommandHandler<UpdateBookRentCommand, UpdateBookRentResult>
{
    public async Task<UpdateBookRentResult> Handle(UpdateBookRentCommand command, CancellationToken cancellationToken)
    {
        var bookRentalId = BookRentalId.Of(command.BookRental.Id);

        var bookRental = await dbContext.BookRent
            .FindAsync([bookRentalId], cancellationToken: cancellationToken);

        if (bookRental == null)
            throw new NotFoundException(command.BookRental.Id.ToString());

        UpdateBookRentalWithNewValues(bookRental, command.BookRental);

        dbContext.BookRent.Update(bookRental);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateBookRentResult(true);
    }

    private void UpdateBookRentalWithNewValues(BookRental bookRental, BookRentalDto bookRentalDto)
    {
        bookRental.Update(
            status: bookRentalDto.Status);
    }
}
