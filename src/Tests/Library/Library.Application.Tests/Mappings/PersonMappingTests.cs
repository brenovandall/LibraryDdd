using Library.Application.Mappings;
using Library.Domain.Enums;
using Library.Domain.ValueObjects;

namespace Library.Application.Tests.Mappings;

public class PersonMappingTests
{
    [Fact]
    public void ToPersonListDto_DeveConverterUmaListaDePersonParaDtoCorretamente()
    {
        var person = new List<Library.Domain.Models.Person>()
        {
            Library.Domain.Models.Person.Create(
                id: PersonId.Of(Guid.Parse("b18c038f-126c-4602-a9d8-82e864a7a353")),
                name: "Breno Van Dall",
                cpf: "10813718390",
                birthDate: new DateTime(2006, 5, 3)),
            Library.Domain.Models.Person.Create(
                id: PersonId.Of(Guid.Parse("8b9000f9-1b74-4790-8fbe-f66331e8cc95")),
                name: "Nicolle Laís",
                cpf: "10813718399",
                birthDate: new DateTime(2002, 5, 3))
        };

        var result = person.ToPersonDtoList().ToArray();

        Assert.Equal(2, result.Count());

        Assert.Equal(result[0].Id, Guid.Parse("b18c038f-126c-4602-a9d8-82e864a7a353"));
        Assert.Equal("Breno Van Dall", result[0].Name);
        Assert.Equal("10813718390", result[0].Cpf);
        Assert.Equal(new DateTime(2006, 5, 3), result[0].BirthDate);

        Assert.Equal(result[1].Id, Guid.Parse("8b9000f9-1b74-4790-8fbe-f66331e8cc95"));
        Assert.Equal("Nicolle Laís", result[1].Name);
        Assert.Equal("10813718399", result[1].Cpf);
        Assert.Equal(new DateTime(2002, 5, 3), result[1].BirthDate);
    }
}
