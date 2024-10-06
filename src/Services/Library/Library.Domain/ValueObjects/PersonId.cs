namespace Library.Domain.ValueObjects;

public record PersonId
{
    public Guid Value { get; }
    private PersonId(Guid value) => Value = value;

    public static PersonId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        if (value == Guid.Empty)
            throw new DomainException("ID da pessoa não pode ser nulo");

        return new PersonId(value);
    }
}
