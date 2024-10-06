namespace Library.Domain.ValueObjects;

public record BookId
{
    public Guid Value { get; }
    private BookId(Guid value) => Value = value;

    public static BookId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        if (value == Guid.Empty)
            throw new DomainException("ID do livro não pode ser nulo");

        return new BookId(value);
    }
}
