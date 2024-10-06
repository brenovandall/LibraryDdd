namespace Library.Domain.Events;

public record BookRentalUpdatedEvent(BookRental bookRental) : IDomainEvent;
