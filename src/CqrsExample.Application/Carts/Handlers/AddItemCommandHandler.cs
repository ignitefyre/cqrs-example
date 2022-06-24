using CqrsExample.Application.Carts.Commands;
using CqrsExample.Domain.Exceptions;
using MediatR;

namespace CqrsExample.Application.Carts.Handlers;

public class AddItemCommandHandler : IRequestHandler<AddItemCommand, bool>
{
    private readonly ICartRepository _cartRepository;
    private readonly IEventRepository _eventRepository;

    public AddItemCommandHandler(ICartRepository cartRepository, IEventRepository eventRepository)
    {
        _cartRepository = cartRepository;
        _eventRepository = eventRepository;
    }
    
    public Task<bool> Handle(AddItemCommand request, CancellationToken cancellationToken)
    {
        var (productId, quantity, cartId) = request;
        
        var cart = _cartRepository.GetById(cartId);
        
        if (cart == null)
            throw new CartNotFoundException();
        
        cart.AddItem(productId, quantity);

        // would not update the cart here, let the stream consumer handle persistence
        _cartRepository.Update(cart);
        
        foreach (var @event in cart.GetUncommittedChanges())
        {
            _eventRepository.Publish(@event, cartId);
        }

        return Task.FromResult(true);
    }
}