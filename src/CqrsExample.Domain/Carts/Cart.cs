namespace CqrsExample.Domain.Carts;

public class Cart : AggregateRoot
{
    public Cart(string id) : base(id) { }
}