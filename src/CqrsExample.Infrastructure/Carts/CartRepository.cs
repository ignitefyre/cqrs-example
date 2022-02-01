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
    
    public Cart? GetById(string id)
    {
        if (_cart.Id != id)
            return null;

        var items = _cart.Items.Select(x => new CartItem(x.Id, x.Quantity)).ToList();
        
        return new Cart(_cart.Id, items);
    }

    public void Update(Cart entity)
    {
        _cart.Items = entity.GetItems().Select(x => new CartItemData(x.Id, x.Quantity)).ToList();
    }
}