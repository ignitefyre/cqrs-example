namespace CqrsExample.Domain.Carts;

public class Cart : AggregateRoot
{
    public Cart(string id) : base(id) { }

    public Cart(string id, ICollection<CartItem> items) : base(id)
    {
        Items = items;
    }
    
    private ICollection<CartItem> Items { get; } = new List<CartItem>();

    public void AddItem(string productId, int quantity)
    {
        Items.Add(new CartItem(productId, quantity));
    }

    public IEnumerable<CartItem> GetItems()
    {
        return Items;
    }
}

public class CartItem
{
    public string Id { get; }
    public int Quantity { get; private set; }

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