using CqrsExample.Application.Carts;
using CqrsExample.Domain.Carts;

namespace CqrsExample.Infrastructure.Carts;

public class CartRepository : ICartRepository
{
    private readonly CartData _cart;

    public CartRepository(string initialCartId)
    {
        _cart = new CartData(initialCartId);
        
    }
    public Cart GetById(string id)
    {
        return _cart.Id == id ? new Cart(_cart.Id) : null;
    }
}