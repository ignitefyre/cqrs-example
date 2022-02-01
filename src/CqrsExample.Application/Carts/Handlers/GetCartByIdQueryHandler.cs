using CqrsExample.Application.Carts.Queries;
using CqrsExample.Domain.Exceptions;
using MediatR;

namespace CqrsExample.Application.Carts.Handlers;

public class GetCartByIdQueryHandler : IRequestHandler<GetCartByIdQuery, CartDto>
{
    private readonly ICartRepository _cartRepository;

    public GetCartByIdQueryHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }
    
    public Task<CartDto> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
    {
        var result = _cartRepository.GetById(request.Id);

        if (result == null)
            throw new CartNotFoundException();

        var items = result.GetItems().Select(x => new CartItemDto(x.Id, x.Quantity)).ToList();

        return Task.FromResult(new CartDto(result.Id, items));
    }
}