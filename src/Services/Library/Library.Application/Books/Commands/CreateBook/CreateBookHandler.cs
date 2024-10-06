
using Library.Domain.Models;
using Library.Domain.ValueObjects;

namespace Library.Application.Books.Commands.CreateBook;

public class CreateBookCommandHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateBookCommand, CreateBookResult>
{
    public async Task<CreateBookResult> Handle(CreateBookCommand command, CancellationToken cancellationToken)
    {
        var book = CreateBook(command.Book);

        dbContext.Books.Add(book);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateBookResult(book.Id.Value);
    }

    private Book CreateBook(BookDto book)
    {
        return Book.Create(
            id: BookId.Of(Guid.NewGuid()),
            name: book.Name,
            publisher: book.Publisher,
            publishDate: book.PublishDate,
            status: book.Status);
    }
}
