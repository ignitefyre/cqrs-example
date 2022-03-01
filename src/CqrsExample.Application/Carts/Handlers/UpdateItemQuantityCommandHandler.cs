using CqrsExample.Application.Carts.Commands;
using CqrsExample.Domain.Exceptions;
using MediatR;

namespace CqrsExample.Application.Carts.Handlers;

public class UpdateItemQuantityCommandHandler : IRequestHandler<UpdateItemQuantityCommand, bool>
{
    private readonly ICartRepository _cartRepository;

    public UpdateItemQuantityCommandHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public Task<bool> Handle(UpdateItemQuantityCommand request, CancellationToken cancellationToken)
    {
        var (productId, quantity, cartId) = request;
        
        var cart = _cartRepository.GetById(cartId);
        
        if (cart == null)
            throw new CartNotFoundException();
        
        if (request.Quantity > 0)
        {
            cart.UpdateItemQuantity(productId, quantity);
        }
        else
        {
            cart.RemoveItem(request.ProductId);
        }
        
        _cartRepository.Update(cart);

        return Task.FromResult(true);
    }
}