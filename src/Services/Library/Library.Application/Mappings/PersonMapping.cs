using Library.Application.Dtos;

namespace Library.Application.Mappings;

public static class PersonMapping
{
    public static IEnumerable<PersonDto> ToPersonDtoList(this IEnumerable<Library.Domain.Models.Person> person)
    {
        return person.Select(p => new PersonDto(
            Id: p.Id.Value,
            Name: p.Name,
            Cpf: p.Cpf,
            BirthDate: p.BirthDate!.Value));
    }
}
