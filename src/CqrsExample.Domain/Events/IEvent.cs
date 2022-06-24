namespace CqrsExample.Domain.Events;

public interface IEvent
{
    Guid Id { get; }
    
    string Context { get; }
}