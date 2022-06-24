using CqrsExample.Domain.Events;

namespace CqrsExample.Application;

public interface IEventRepository
{
    Task Publish(IEvent @event);

    Task Publish(IEvent @event, string aggregateId);
}