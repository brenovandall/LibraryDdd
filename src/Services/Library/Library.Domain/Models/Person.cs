namespace Library.Domain.Models;

public class Person : Entity<PersonId>
{
    public string Name { get; private set; } = default!;
    public string Cpf { get; private set; } = default!;
    public DateTime? BirthDate { get; private set; }

    public static Person Create(PersonId id, string name, string cpf, DateTime? birthDate)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));
        ArgumentException.ThrowIfNullOrWhiteSpace(cpf, nameof(cpf));

        return new Person { Id = id, Name = name, Cpf = cpf, BirthDate = birthDate };
    }
}
