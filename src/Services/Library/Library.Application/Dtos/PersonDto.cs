namespace Library.Application.Dtos;

public record PersonDto(
    Guid Id,
    string Name,
    string Cpf,
    DateTime? BirthDate);
