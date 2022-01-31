using CqrsExample.Application.Carts.Queries;
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
        throw new NotImplementedException();
    }
}