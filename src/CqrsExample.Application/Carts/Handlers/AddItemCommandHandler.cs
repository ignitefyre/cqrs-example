using CqrsExample.Application.Carts.Commands;
using CqrsExample.Domain.Exceptions;
using MediatR;

namespace CqrsExample.Application.Carts.Handlers;

public class AddItemCommandHandler : IRequestHandler<AddItemCommand, bool>
{
    private readonly ICartRepository _cartRepository;

    public AddItemCommandHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }
    
    public Task<bool> Handle(AddItemCommand request, CancellationToken cancellationToken)
    {
        var (productId, quantity, cartId) = request;
        
        var cart = _cartRepository.GetById(cartId);
        
        if (cart == null)
            throw new CartNotFoundException();
        
        cart.AddItem(productId, quantity);

        _cartRepository.Update(cart);

        return Task.FromResult(true);
    }
}