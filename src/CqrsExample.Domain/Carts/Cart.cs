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