using MediatR;

namespace Library.Domain.Abstractions;

public interface IDomainEvent : INotification
{
    Guid Id => Guid.NewGuid();
    public DateTime OccuredOn => DateTime.Now;
    public string EventType => GetType().AssemblyQualifiedName!;
}
