using Library.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Library.Application.BookRent.EventHandlers.Domain;

public class BookRentalCreatedEventHandler(ILogger<BookRentalCreatedEventHandler> logger) 
    : INotificationHandler<BookRentalCreatedEvent>
{
    public async Task Handle(BookRentalCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain event handled: {DomainEvent}", domainEvent.GetType().Name);
    }
}
