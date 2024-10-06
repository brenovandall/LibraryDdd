namespace Library.Domain.Events;

public record BookRentalCreatedEvent(BookRental bookRental) : IDomainEvent;
