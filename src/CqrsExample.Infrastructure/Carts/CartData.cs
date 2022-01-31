namespace CqrsExample.Infrastructure.Carts;

public class CartData
{
    public CartData(string initialCartId)
    {
        Id = initialCartId;
    }
    public string Id { get; }
}