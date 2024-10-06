namespace Library.Domain.Models;

public class BookRental : Aggregate<BookRentalId>
{
    public BookId BookId { get; private set; } = default!;
    public PersonId PersonId { get; private set; } = default!;
    public DateTime StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    public BookRentStatus Status { get; private set; }

    public static BookRental Create(
        BookRentalId id,
        BookId bookId,
        PersonId personId,
        DateTime startDate,
        DateTime? endDate,
        BookRentStatus status)
    {
        var rent = new BookRental()
        {
            Id = id,
            BookId = bookId,
            PersonId = personId,
            StartDate = startDate,
            EndDate = endDate,
            Status = status
        };

        rent.AddDomainEvent(new BookRentalCreatedEvent(bookRental: rent));

        return rent;
    }

    public void Update(BookRentStatus status)
    {
        Status = status;

        AddDomainEvent(new BookRentalUpdatedEvent(bookRental: this));
    }
}
