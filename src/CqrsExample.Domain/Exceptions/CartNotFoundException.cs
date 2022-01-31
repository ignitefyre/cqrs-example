namespace CqrsExample.Domain.Exceptions;

public class CartNotFoundException : Exception
{
    public CartNotFoundException() : base("Cart not found!")
    {
        
    }
}