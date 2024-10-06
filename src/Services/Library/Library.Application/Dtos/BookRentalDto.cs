using Library.Domain.Enums;
using Library.Domain.ValueObjects;

namespace Library.Application.Dtos;

public record BookRentalDto(
    Guid Id,
    BookId BookId,
    PersonId PersonId,
    DateTime StartDate,
    DateTime? EndDate,
    BookRentStatus Status);
