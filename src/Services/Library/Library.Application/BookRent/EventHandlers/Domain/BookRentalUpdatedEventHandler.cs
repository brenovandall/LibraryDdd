using Library.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Library.Application.BookRent.EventHandlers.Domain;

public class BookRentalUpdatedEventHandler(ILogger<BookRentalUpdatedEventHandler> logger)
    : INotificationHandler<BookRentalUpdatedEvent>
{
    public async Task Handle(BookRentalUpdatedEvent domainEvent, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain event handled: {DomainEvent}", domainEvent.GetType().Name);
    }
}
