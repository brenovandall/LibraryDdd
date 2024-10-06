namespace Library.Domain.Models;

public class Book : Entity<BookId>
{
    public string Name { get; private set; } = default!;
    public string Publisher { get; private set; } = default!;
    public DateTime? PublishDate { get; private set; }
    public BookStatus Status { get; private set; }

    public static Book Create(BookId id, string name, string publisher, DateTime? publishDate, BookStatus? status)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));
        ArgumentException.ThrowIfNullOrWhiteSpace(publisher, nameof(publisher));
        if (!Enum.IsDefined(typeof(BookStatus), status))
            throw new ArgumentOutOfRangeException(nameof(status), "Status inválido.");

        return new Book { Id = id, Name = name, Publisher = publisher, PublishDate = publishDate, Status = status.Value };
    }
}
