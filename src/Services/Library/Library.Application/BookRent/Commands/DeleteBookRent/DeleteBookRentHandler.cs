
using BuildingBlocks.Exceptions;
using Library.Domain.ValueObjects;

namespace Library.Application.BookRent.Commands.DeleteBookRent;

public class DeleteBookRentCommandHandler(IApplicationDbContext dbContext)
    : ICommandHandler<DeleteBookRentCommand, DeleteBookRentResult>
{
    public async Task<DeleteBookRentResult> Handle(DeleteBookRentCommand command, CancellationToken cancellationToken)
    {
        var bookRentalId = BookRentalId.Of(command.BookRentalId);

        var bookRental = await dbContext.BookRent
            .FindAsync([bookRentalId], cancellationToken: cancellationToken);

        if (bookRental == null)
            throw new NotFoundException(command.BookRentalId.ToString());

        dbContext.BookRent.Remove(bookRental);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteBookRentResult(true);
    }
}
