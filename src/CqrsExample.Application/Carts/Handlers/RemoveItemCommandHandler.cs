using CqrsExample.Application.Carts.Commands;
using CqrsExample.Domain.Exceptions;
using MediatR;

namespace CqrsExample.Application.Carts.Handlers;

public class RemoveItemCommandHandler : IRequestHandler<RemoveItemCommand, bool>
{
    private readonly ICartRepository _cartRepository;

    public RemoveItemCommandHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public Task<bool> Handle(RemoveItemCommand request, CancellationToken cancellationToken)
    {
        var (productId, cartId) = request;
        
        var cart = _cartRepository.GetById(cartId);
        
        if (cart == null)
            throw new CartNotFoundException();
        
        cart.RemoveItem(productId);

        _cartRepository.Update(cart);

        return Task.FromResult(true);
    }
}