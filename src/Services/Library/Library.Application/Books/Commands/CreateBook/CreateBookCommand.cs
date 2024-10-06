namespace Library.Application.Books.Commands.CreateBook;

public record CreateBookCommand(BookDto Book): ICommand<CreateBookResult>;
public record CreateBookResult(Guid Id);
