﻿namespace Library.Domain.Abstractions;

public class Aggregate<Tid> : Entity<Tid>, IAggregate<Tid>
{
    private readonly List<IDomainEvent> _domainEvents = [];
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);

    public IDomainEvent[] ClearDomainEvents()
    {
        IDomainEvent[] dequeuedDomainEvents = _domainEvents.ToArray();

        _domainEvents.Clear();

        return dequeuedDomainEvents;
    }
}
