using Library.Domain.Models;

namespace Library.Application.Mappings;

public static class BookMapping
{
    public static IEnumerable<BookDto> ToBookDtoList(this IEnumerable<Book> books)
    {
        return books.Select(b => new BookDto(
            Id: b.Id.Value,
            Name: b.Name,
            Publisher: b.Publisher,
            PublishDate: b.PublishDate!.Value,
            Status: b.Status));
    }
}
