using Library.Domain.Models;
using Library.Domain.ValueObjects;

namespace Library.Application.Mappings;

public static class BookRentalMapping
{
    public static IEnumerable<BookRentalDto> ToBookRentalDtoList(this IEnumerable<BookRental> bookRents)
    {
        return bookRents.Select(b => new BookRentalDto(
            Id: b.Id.Value,
            BookId: BookId.Of(b.BookId.Value),
            PersonId: PersonId.Of(b.PersonId.Value),
            StartDate: b.StartDate,
            EndDate: b.EndDate,
            Status: b.Status));
    }
}
