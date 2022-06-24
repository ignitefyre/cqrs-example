using System.Text;
using CqrsExample.Application;
using CqrsExample.Domain.Events;
using EventStore.Client;
using Newtonsoft.Json;

namespace CqrsExample.Infrastructure;

public class EventRepository : IEventRepository
{
    private readonly EventStoreClient _client;
    private static string StreamId(string context, string aggregateId) => $"{context}|{aggregateId}";

    public EventRepository()
    {
        _client = new EventStoreClient(
            EventStoreClientSettings.Create("esdb://192.168.86.236:2113?tls=false"));
    }
    
    public Task Publish(IEvent @event)
    {
        throw new NotImplementedException();
    }

    public async Task Publish(IEvent @event, string aggregateId)
    {
        var data = JsonConvert.SerializeObject(@event);
        var payload = Encoding.UTF8.GetBytes(data);
        var eventData = new EventData(Uuid.NewUuid(), @event.GetType().Name, payload);
        
        await _client.AppendToStreamAsync(StreamId(@event.Context, aggregateId), StreamState.Any, new[] {eventData});
    }
}