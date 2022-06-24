using CqrsExample.Domain.Events;

namespace CqrsExample.Domain.Carts;

public class Cart : AggregateRoot
{
    public Cart(string id) : base(id) { }

    public Cart(string id, ICollection<CartItem> items) : base(id)
    {
        Items = items;
    }
    
    private readonly List<IEvent> _changes = new List<IEvent>();
    
    private ICollection<CartItem> Items { get; } = new List<CartItem>();

    public void AddItem(string productId, int quantity)
    {
        Items.Add(new CartItem(productId, quantity));
        
        _changes.Add(new ItemAddedEvent(productId, quantity, Id));
    }

    public void UpdateItemQuantity(string productId, int quantity)
    {
        var item = Items.FirstOrDefault(x => x.Id == productId);

        item?.UpdateQuantity(quantity);
    }

    public void RemoveItem(string productId)
    {
        var item = Items.FirstOrDefault(x => x.Id == productId);

        if (item != null)
            Items.Remove(item);
    }

    public IEnumerable<CartItem> GetItems()
    {
        return Items;
    }
    
    public IEnumerable<IEvent> GetUncommittedChanges() {
        return _changes;
    }

}