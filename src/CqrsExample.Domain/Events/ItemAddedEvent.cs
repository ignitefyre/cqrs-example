namespace CqrsExample.Domain.Events;

public record ItemAddedEvent(string ProductId, int Quantity, string CartId) : IEvent
{
    public Guid Id => Guid.NewGuid();
    public string Context => "Carts";
}