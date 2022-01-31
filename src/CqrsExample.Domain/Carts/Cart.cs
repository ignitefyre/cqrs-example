namespace CqrsExample.Domain.Carts;

public class Cart : AggregateRoot
{
    public Cart(string id) : base(id) { }
    
    private ICollection<CartItem> _items { get; } = new List<CartItem>();

    public void AddItem(CartItem item)
    {
        _items.Add(item);
    }
}

public class CartItem
{
    public string Id { get; }
    public int Quantity { get; internal set; }

    public CartItem(string id, int quantity)
    {
        Id = id;
        Quantity = quantity;
    }

    public void UpdateQuantity(int quantity)
    {
        Quantity = quantity;
    }
}