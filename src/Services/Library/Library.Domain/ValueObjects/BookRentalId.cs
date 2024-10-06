namespace Library.Domain.ValueObjects;

public record BookRentalId
{
    public Guid Value { get; }
    private BookRentalId(Guid value) => Value = value;

    public static BookRentalId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        if (value == Guid.Empty)
            throw new DomainException("ID não pode ser nulo");

        return new BookRentalId(value);
    }
}
