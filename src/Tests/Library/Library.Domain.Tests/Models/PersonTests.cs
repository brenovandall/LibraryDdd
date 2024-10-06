using FluentAssertions;
using Library.Domain.Models;
using Library.Domain.ValueObjects;

namespace Library.Domain.Tests.Models;

public class PersonTests
{
    [Fact]
    public void Criar_DeveReotornarPerson_QuandoDadosValidosSaoFornecidos()
    {
        var id = PersonId.Of(Guid.NewGuid());
        var name = "Breno Van Dall";
        var cpf = "10638013940";
        var birthDate = new DateTime(2006, 5, 3);

        var person = Person.Create(id, name, cpf, birthDate);

        person.Should().NotBeNull();
        person.Name.Should().Be(name);
        person.Cpf.Should().Be(cpf);
        person.BirthDate.Should().Be(birthDate);
        person.Id.Should().Be(id);
    }

    [Fact]
    public void Criar_DeveReotornarArgumentException_QuandoNomeForNulo()
    {
        var id = PersonId.Of(Guid.NewGuid());
        var cpf = "10638013940";
        var birthDate = new DateTime(2006, 5, 3);

        Action act = () => Person.Create(id, null, cpf, birthDate);

        act.Should().Throw<ArgumentException>()
            .WithMessage("Value cannot be null. (Parameter 'name')");
    }

    [Fact]
    public void Criar_DeveReotornarArgumentException_QuandoCpfForNulo()
    {
        var id = PersonId.Of(Guid.NewGuid());
        var name = "Breno Van Dall";
        var birthDate = new DateTime(2006, 5, 3);

        Action act = () => Person.Create(id, name, null, birthDate);

        act.Should().Throw<ArgumentException>()
            .WithMessage("Value cannot be null. (Parameter 'cpf')");
    }

    [Fact]
    public void Criar_DeveAceitarBirthDateNull()
    {
        var id = PersonId.Of(Guid.NewGuid());
        var name = "Breno Van Dall";
        var cpf = "10638013940";

        var person = Person.Create(id, name, cpf, null);

        person.BirthDate.Should().BeNull();
    }
}
