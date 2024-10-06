using Library.Domain.Enums;

namespace Library.Application.Dtos;

public record BookDto(
    Guid Id,
    string Name,
    string Publisher,
    DateTime? PublishDate,
    BookStatus Status);
